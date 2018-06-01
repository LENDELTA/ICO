using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Trades
{
    public class TradesViewModel
    {
        public List<OrderModel> Trades { get; set; }

        public int Total { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public BrokerTradeServerType TradeServerType { get; set; }
    }
}
