using LENDELTA.Core.ViewModels.Manager;
using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Broker
{
    public class BrokerInitData
    {
        public List<ManagerRequest> NewManagerRequest { get; set; }
        public List<BrokerInvestmentProgram> Investments { get; set; }
        public int HoursOffset { get; set; }
    }
}
