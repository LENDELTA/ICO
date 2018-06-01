using System;
using System.Collections.Generic;
using LENDELTA.Core.ViewModels.Account;
using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class InvestmentProgram : ITournament
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string Logo { get; set; }
        public bool IsEnabled { get; set; }
        public decimal Balance { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
        public int TradesCount { get; set; }
        public int InvestorsCount { get; set; }
        public int PeriodDuration { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public decimal ProfitAvg { get; set; }
        public decimal ProfitTotal { get; set; }
        public decimal ProfitAvgPercent { get; set; }
        public decimal ProfitTotalPercent { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ChangeStatus ProfitTotalChange { get; set; }
        public decimal AvailableInvestment { get; set; }
        public decimal FeeSuccess { get; set; }
        public decimal FeeManagement { get; set; }
        [Obsolete("Replaced by EquityChart")]
        public List<Chart> Chart { get; set; }
        public List<ChartByDate> EquityChart { get; set; }
        public ProfilePublicViewModel Manager { get; set; }
        public FreeTokens FreeTokens { get; set; }

        public bool HasNewRequests { get; set; }
        public bool IsInvestEnable { get; set; }
        public bool IsOwnProgram { get; set; }
        public bool CanCloseProgram { get; set; }
        public bool IsFavorite { get; set; }

        public bool IsTournament { get; set; }
        public int? RoundNumber { get; set; }
        public int? Place { get; set; }
    }
}
