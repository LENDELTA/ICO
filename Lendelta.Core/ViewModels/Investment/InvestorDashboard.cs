using System.Collections.Generic;

namespace GenesisVision.Core.ViewModels.Investment
{
    public class InvestorDashboard
    {
        public List<InvestmentProgramDashboardInvestor> InvestmentPrograms { get; set; }

        public decimal ProfitFromPrograms { get; set; }

        public decimal InvestedAmount { get; set; }

        public decimal TotalPortfolioAmount { get; set; }
    }
}
