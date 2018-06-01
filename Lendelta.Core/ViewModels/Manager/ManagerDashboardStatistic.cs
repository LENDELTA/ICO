using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Manager
{
    public class ManagerDashboardStatistic
    {
        public List<ProgramBalances> ProgramBalances { get; set; }
        public int InvestorsCount { get; set; }
        public decimal InvestorsFund { get; set; }
        public EndOfNextPeriod EndOfNextPeriod { get; set; }
        public decimal TotalProfit { get; set; }
        public List<ManagerFundChart> FundChart { get; set; }
        public List<ManagerProfitChart> ProfitChart { get; set; }
    }

    public class ProgramBalances
    {
        public string Title { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceUsd { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
    }

    public class EndOfNextPeriod
    {
        public string Title { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public int Duration { get; set; }
    }

    public class ManagerFundChart
    {
        public string Title { get; set; }
        public decimal ManagerFund { get; set; }
        public decimal InvestorFund { get; set; }
        public decimal Profit { get; set; }
    }

    public class ManagerProfitChart
    {
        public string Title { get; set; }
        public List<ManagerProfitChartData> Data { get; set; }
    }

    public class ManagerProfitChartData
    {
        public DateTime Date { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
