using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class InvestmentProgramRequests
    {
        public IEnumerable<InvestmentProgramRequest> Requests { get; set; }

        public int Total { get; set; }
    }
}
