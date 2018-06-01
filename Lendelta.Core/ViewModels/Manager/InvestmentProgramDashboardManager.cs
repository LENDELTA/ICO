using GenesisVision.Core.ViewModels.Investment;
using GenesisVision.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace GenesisVision.Core.ViewModels.Manager
{
    public class InvestmentProgramDashboardManager : ITournament
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string Logo { get; set; }
        public decimal Balance { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
        public int TradesCount { get; set; }
        public int PeriodDuration { get; set; }
        public int InvestorsCount { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public decimal ProfitTotal { get; set; }
        public decimal ProfitTotalGvt { get; set; }
        public decimal ProfitCurrent { get; set; }
        public bool IsInvestEnable { get; set; }
        public bool IsWithdrawEnable { get; set; }
        public Token Token { get; set; }
        public decimal OwnBalance { get; set; }
        public decimal MinAccountBalanceUsd { get; set; }
        public decimal MinAccountBalance { get; set; }
        public string Login { get; set; }
        public bool CanCloseProgram { get; set; }
        public bool CanClosePeriod { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsPending { get; set; }

        public bool IsTournament { get; set; }
        public int? RoundNumber { get; set; }
        public int? Place { get; set; }
    }
}
