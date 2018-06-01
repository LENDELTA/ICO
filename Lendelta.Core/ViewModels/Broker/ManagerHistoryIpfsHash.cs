using System;
using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Broker
{
    public class ManagerHistoryIpfsHash
    {
        public IEnumerable<ManagerIpfsHash> ManagersHashes { get; set; }
    }

    public class ManagerIpfsHash
    {
        public Guid ManagerId { get; set; }
        public string IpfsHash { get; set; }
    }
}
