using GenesisVision.Common.Models;
using GenesisVision.Common.Services;
using GenesisVision.Common.Services.Interfaces;
using GenesisVision.Core.Helpers;
using GenesisVision.Core.Helpers.Convertors;
using GenesisVision.Core.Helpers.TokenHelper;
using GenesisVision.Core.Infrastructure.Filters;
using GenesisVision.Core.Infrastructure.Middlewares;
using GenesisVision.Core.Services;
using GenesisVision.Core.Services.Interfaces;
using GenesisVision.Core.Services.Validators;
using GenesisVision.Core.Services.Validators.Interfaces;
using GenesisVision.DataModel;
using GenesisVision.DataModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GenesisVision.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureConstants();

            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            var dbContextOptions = new Action<NpgsqlDbContextOptionsBuilder>(options => options.MigrationsAssembly("GenesisVision.Core"));

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<ApplicationDbContext>(x => x.UseNpgsql(connectionString, dbContextOptions));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                    {
                        options.Password.RequiredLength = 6;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.Lockout = new LockoutOptions
                                          {
                                              AllowedForNewUsers = true,
                                              DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                                              MaxFailedAccessAttempts = 20
                                          };
                    })
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                                                            {
                                                                RequireExpirationTime = true,
                                                                RequireSignedTokens = true,

                                                                ValidateIssuer = true,
                                                                ValidateAudience = true,
                                                                ValidateLifetime = true,
                                                                ValidateIssuerSigningKey = true,

                                                                ValidIssuer = Constants.JwtValidIssuer,
                                                                ValidAudience = Constants.JwtValidAudience,
                                                                IssuerSigningKey = JwtSecurityKey.Create(Constants.JwtSecretKey)
                                                            };
                        //options.RequireHttpsMetadata = true;
                        options.SaveToken = true;
                        options.Events = new JwtBearerEvents
                                         {
                                             OnAuthenticationFailed = context =>
                                             {
                                                 Console.WriteLine(
                                                     "OnAuthenticationFailed: " + context.Exception.Message);
                                                 return Task.CompletedTask;
                                             },
                                             OnTokenValidated = context =>
                                             {
                                                 Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                                 return Task.CompletedTask;
                                             }
                                         };
                    });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = GetMultipartBodyLengthLimit();
            });

            services.AddMemoryCache()
                    .AddMvcCore()
                    .AddApiExplorer()
                    .AddAuthorization()
                    .AddDataAnnotations()
                    .AddJsonFormatters()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz";
                    });

            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            ConfigureCustomServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                                   {
                                       Title = "Core API",
                                       Version = "v1",
                                       Contact = new Contact
                                                 {
                                                     Name = "Genesis Vision",
                                                     Url = "https://genesis.vision/"
                                                 }
                                   });
                c.DescribeAllEnumsAsStrings();
                c.TagActionsBy(x => x.RelativePath.Split("/").Take(2).Last());
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                c.OperationFilter<FileUploadOperation>();

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "GenesisVision.Core.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        private void ConfigureConstants()
        {
            var periodInMinutesStr = Configuration["Testing:IsPeriodInMinutes"];
            if (!string.IsNullOrEmpty(periodInMinutesStr) && bool.TryParse(periodInMinutesStr, out var periodInMinutes))
                Constants.IsPeriodInMinutes = periodInMinutes;

            var autoConfirmEmailStr = Configuration["Testing:AutoConfirmEmail"];
            if (!string.IsNullOrEmpty(autoConfirmEmailStr) && bool.TryParse(autoConfirmEmailStr, out var autoConfirmEmail))
                Constants.AutoConfirmEmail = autoConfirmEmail;

            var testDepositAmountStr = Configuration["Testing:ManagerDepositAmount"];
            if (!string.IsNullOrEmpty(testDepositAmountStr) && decimal.TryParse(testDepositAmountStr, out var testDepositAmount))
                Constants.ManagerTestDepositAmount = testDepositAmount;

            testDepositAmountStr = Configuration["Testing:InvestorDepositAmount"];
            if (!string.IsNullOrEmpty(testDepositAmountStr) && decimal.TryParse(testDepositAmountStr, out testDepositAmount))
                Constants.InvestorTestDepositAmount = testDepositAmount;


            if (Guid.TryParse(Configuration["GVWalletId"], out var walletId))
                Constants.GVWalletId = walletId;


            Constants.ConfirmEmailUrlManager = Configuration["ConfirmEmailUrlManager"];
            Constants.ConfirmEmailUrlInvestor = Configuration["ConfirmEmailUrlInvestor"];
            Constants.ResetPasswordUrlManager = Configuration["ResetPasswordUrlManager"];
            Constants.ResetPasswordUrlInvestor = Configuration["ResetPasswordUrlInvestor"];


            var ipfsHost = Configuration["IpfsHost"];
            if (!string.IsNullOrEmpty(ipfsHost) && !string.IsNullOrWhiteSpace(ipfsHost))
                Constants.IpfsHost = ipfsHost;

            var gethHost = Configuration["GethHost"];
            if (!string.IsNullOrEmpty(gethHost) && !string.IsNullOrWhiteSpace(gethHost))
                Constants.GethHost = gethHost;


            var minInvestAmountStr = Configuration["MinInvestAmount"];
            if (!string.IsNullOrEmpty(minInvestAmountStr) && decimal.TryParse(minInvestAmountStr, out var minInvestAmount))
                Constants.MinInvestAmount = minInvestAmount;

            var gvCommissionPercentStr = Configuration["GvCommissionPercent"];
            if (!string.IsNullOrEmpty(gvCommissionPercentStr) && decimal.TryParse(gvCommissionPercentStr, out var gvCommissionPercent))
                Constants.GvCommissionPercent = gvCommissionPercent;


            Constants.JwtValidIssuer = Configuration["JWT:ValidIssuer"];
            Constants.JwtValidAudience = Configuration["JWT:ValidAudience"];
            Constants.JwtSecretKey = Configuration["JWT:SecretKey"];

            var expiryInMinutesStr = Configuration["JWT:ExpiryInMinutes"];
            if (!string.IsNullOrEmpty(expiryInMinutesStr) && int.TryParse(expiryInMinutesStr, out var expiryInMinutes))
                Constants.JwtExpiryInMinutes = expiryInMinutes;


            Constants.SendGridApiKey = Configuration["EmailSender:SendGrid:ApiKey"];
            Constants.SendGridFromEmail = Configuration["EmailSender:SendGrid:FromEmail"];
            Constants.SendGridFromName = Configuration["EmailSender:SendGrid:FromName"];
        }

        private int GetMultipartBodyLengthLimit()
        {
            var multipartBodyLengthLimit = 2097152;

            var str = Configuration["MultipartBodyLengthLimit"];
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out var expiryInMinutes))
                multipartBodyLengthLimit = expiryInMinutes;

            return multipartBodyLengthLimit;
        }

        private (int, int) GetResizeImageValues()
        {
            var quality = 85;
            var str = Configuration["ResizeImage:Quality"];
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out var newQuality) && newQuality > 0)
                quality = newQuality;

            var size = 300;
            str = Configuration["ResizeImage:Size"];
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out var newSize) && newSize > 0)
                size = newSize;

            return (quality, size);
        }

        private void ConfigureCustomServices(IServiceCollection services)
        {
            services.AddTransient<IProgramsService, ProgramsService>();
            services.AddTransient<IBrokerProgramsService, BrokerProgramsService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IPaymentAddressService, GvPaymentAddressService>();
            services.AddTransient<IManagerService, ManagerService>();
            services.AddTransient<ISmartContractService, SmartContractService>();
            services.AddTransient<IStatisticService, StatisticService>();
            services.AddTransient<ITradesService, TradesService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmailGenerator, EmailGenerator>();
            services.AddTransient<IRateService, RateService>();
            services.AddTransient<IEthService, EthService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IManagerLevelProcessor, ManagerLevelProcessor>();
            
            services.AddTransient<IFilter, Filter>();
            services.AddTransient<IInvestmentProgramsSorter, InvestmentProgramsSorter>();
            services.AddTransient<IChartMaker, ChartMaker>();
            services.AddTransient<IProgramsVmMaker, ProgramsVmMaker>();
            services.AddTransient<IManagerProgramsService, ManagerProgramsService>();
            services.AddTransient<IMoneyService, MoneyService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPlatformInfoService, PlatformInfoService>();
            services.AddTransient<ITournamentRatingService, TournamentRatingService>();
            services.AddTransient<IInvestmentLimitService, InvestmentLimitService>();
            
            var resizeImageValues = GetResizeImageValues();
            services.AddTransient<IImageService, ImageService>(x => new ImageService(resizeImageValues.Item1, resizeImageValues.Item2));

            services.AddTransient<IManagerValidator, ManagerValidator>();
            services.AddTransient<IBrokerValidator, BrokerValidator>();
            services.AddTransient<IInvestorValidator, InvestorValidator>();

            services.Configure<GvPaymentGatewayConfig>(Configuration.GetSection(nameof(GvPaymentGatewayConfig)));
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<GvPaymentGatewayConfig>>().Value);

            services.AddSingleton<IIpfsService, IpfsService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Constants.UploadPath = Path.Combine(env.WebRootPath ?? "", "uploads");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[]
                                    {
                                        new CultureInfo("en-US"),
                                    };
            app.UseRequestLocalization(new RequestLocalizationOptions
                                       {
                                           DefaultRequestCulture = new RequestCulture("en-US"),
                                           SupportedCultures = supportedCultures,
                                           SupportedUICultures = supportedCultures
                                       });

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseMiddleware<AuthMiddleware>();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API v1");
            });
        }
    }
}
