using LENDELTA.Core.ViewModels.Common;
using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Broker
{
    public class BrokersFilter : PagingFilter
    {
        public string BrokerName { get; set; }

        public string TradeServerName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BrokerTradeServerType? TradeServerType { get; set; }
    }
}
