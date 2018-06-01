using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Web;
using System;
using System.IO;

namespace LENDELTA.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("Init LENDELTA.Core");
                BuildWebHost(args).Run();
            }
            catch (Exception e)
            {
                logger.Fatal($"Application stopped: {e.Message} {Environment.NewLine}{e.StackTrace}");
                throw;
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel()
                   .UseIISIntegration()
                   .UseContentRoot(Directory.GetCurrentDirectory())
                   .UseStartup<Startup>()
                   .UseNLog()
                   .Build();
    }
}
