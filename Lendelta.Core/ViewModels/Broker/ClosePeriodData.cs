using LENDELTA.Core.ViewModels.Investment;
using System.Collections.Generic;
using LENDELTA.DataModel.Enums;

namespace LENDELTA.Core.ViewModels.Broker
{
    public class ClosePeriodData
    {
        public Period CurrentPeriod { get; set; }

        public List<InvestorAmount> TokenHolders { get; set; }

        public bool CanCloseCurrentPeriod { get; set; }

        public InvestmentProgramStatus InvestmentProgramStatus { get; set; }
    }
}
