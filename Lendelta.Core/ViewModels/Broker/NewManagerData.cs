using LENDELTA.DataModel.Enums;
using System;

namespace LENDELTA.Core.ViewModels.Broker
{
    public class NewManagerData
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string TradeServerHost { get; set; }
        public string TradeServerName { get; set; }
        public BrokerTradeServerType TradeServerType { get; set; }
        public string BrokerName { get; set; }
        public decimal DepositAmount { get; set; }
    }
}
