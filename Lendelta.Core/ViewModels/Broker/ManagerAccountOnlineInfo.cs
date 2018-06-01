using System;

namespace LENDELTA.Core.ViewModels.Broker
{
    public class ManagerAccountOnlineInfo
    {
        public Guid ManagerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Equity { get; set; }
    }
}
