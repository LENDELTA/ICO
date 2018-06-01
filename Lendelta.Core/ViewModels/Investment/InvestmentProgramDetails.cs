using System;
using System.Collections.Generic;
using LENDELTA.Core.ViewModels.Account;
using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class InvestmentProgramDetails : ITournament
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string Login { get; set; }
        public string Logo { get; set; }
        public decimal Balance { get; set; }
        public decimal OwnBalance { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
        public decimal InvestedTokens { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal ProfitFromProgram { get; set; }
        public int TradesCount { get; set; }
        public int InvestorsCount { get; set; }
        public int PeriodDuration { get; set; }
        public DateTime ProgramStartDate { get; set; }
        public DateTime? ProgramEndDate { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public decimal ProfitAvg { get; set; }
        public decimal ProfitTotal { get; set; }
        public decimal ProfitAvgPercent { get; set; }
        public decimal ProfitTotalPercent { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ChangeStatus ProfitTotalChange { get; set; }
        public decimal VolumeTotal { get; set; }
        public decimal VolumeAvg { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ChangeStatus VolumeTotalChange { get; set; }
        public decimal AvailableInvestment { get; set; }
        public decimal FeeSuccess { get; set; }
        public decimal FeeManagement { get; set; }
        public string IpfsHash { get; set; }
        public string TradeIpfsHash { get; set; }
        public bool IsEnabled { get; set; }
        public decimal MinAccountBalanceUsd { get; set; }
        public decimal MinAccountBalance { get; set; }
        public List<Chart> Chart { get; set; }
        public string BrokerTitle { get; set; }
        public string BrokerTradeServerTitle { get; set; }

        public Token Token { get; set; }
        public ProfilePublicViewModel Manager { get; set; }
        public PeriodProfitDiagram ProfitDiagram { get; set; }
        public FreeTokens FreeTokens { get; set; }

        public bool HasNewRequests { get; set; }
        public bool IsHistoryEnable { get; set; }
        public bool IsInvestEnable { get; set; }
        public bool IsWithdrawEnable { get; set; }
        public bool IsOwnProgram { get; set; }
        public bool CanCloseProgram { get; set; }
        public bool CanClosePeriod { get; set; }
        public bool IsFavorite { get; set; }
        
        public bool IsTournament { get; set; }
        public int? RoundNumber { get; set; }
        public int? Place { get; set; }
    }

    public class PeriodProfitDiagram
    {
        public decimal ManagerFund { get; set; }
        public decimal InvestorsFund { get; set; }
        public decimal Profit { get; set; }
        public bool ProfitIsPositive { get; set; }
    }
}
