using GenesisVision.Core.ViewModels.Investment;
using System.Collections.Generic;
using GenesisVision.DataModel.Enums;

namespace GenesisVision.Core.ViewModels.Broker
{
    public class ClosePeriodData
    {
        public Period CurrentPeriod { get; set; }

        public List<InvestorAmount> TokenHolders { get; set; }

        public bool CanCloseCurrentPeriod { get; set; }

        public InvestmentProgramStatus InvestmentProgramStatus { get; set; }
    }
}
