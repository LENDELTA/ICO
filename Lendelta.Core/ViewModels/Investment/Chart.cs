using System;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class Chart
    {
        public DateTime Date { get; set; }
        public decimal ManagerFund { get; set; }
        public decimal InvestorFund { get; set; }
        public decimal Profit { get; set; }
        public decimal Loss { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
