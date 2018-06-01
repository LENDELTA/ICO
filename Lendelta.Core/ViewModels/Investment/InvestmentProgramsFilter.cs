using GenesisVision.Core.ViewModels.Common;
using GenesisVision.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace GenesisVision.Core.ViewModels.Investment
{
    public enum Sorting
    {
        ByLevelAsc = 0,
        ByLevelDesc = 1,
        ByProfitAsc = 2,
        ByProfitDesc = 3,
        ByOrdersAsc = 4,
        ByOrdersDesc = 5,
        ByEndOfPeriodAsc = 6,
        ByEndOfPeriodDesc = 7,
        ByTitleAsc = 8,
        ByTitleDesc = 9,
        ByBalanceAsc = 10,
        ByBalanceDesc = 11,
    }

    public class InvestmentProgramsFilter : PagingFilter
    {
        public Guid? ManagerId { get; set; }
        public Guid? BrokerId { get; set; }
        public Guid? BrokerTradeServerId { get; set; }
        public decimal? InvestMaxAmountFrom { get; set; }
        public decimal? InvestMaxAmountTo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Sorting? Sorting { get; set; }
        public string Name { get; set; }
        public int? LevelMin { get; set; }
        public int? LevelMax { get; set; }
        public decimal? BalanceUsdMin { get; set; }
        public decimal? BalanceUsdMax { get; set; }
        public decimal? ProfitAvgMin { get; set; }
        public decimal? ProfitAvgMax { get; set; }
        public decimal? ProfitTotalMin { get; set; }
        public decimal? ProfitTotalMax { get; set; }
        public decimal? ProfitTotalPercentMin { get; set; }
        public decimal? ProfitTotalPercentMax { get; set; }
        public decimal? ProfitAvgPercentMin { get; set; }
        public decimal? ProfitAvgPercentMax { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ChangeStatus? ProfitTotalChange { get; set; }
        public int? PeriodMin { get; set; }
        public int? PeriodMax { get; set; }
        public bool ShowActivePrograms { get; set; } = false;
        public int? EquityChartLength { get; set; }
        public bool ShowMyFavorites { get; set; }
        public int? RoundNumber { get; set; }

        [JsonIgnore]
        public bool IsTournamentRequest => RoundNumber.HasValue;
    }
}
