using System;
using GenesisVision.Core.ViewModels.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GenesisVision.Core.ViewModels.Trades
{
    public enum TradeSorting
    {
        ByDateAsk = 0,
        ByDateDesc = 1,
        ByTicketAsk = 2,
        ByTicketDesc = 3,
        BySymbolAsk = 4,
        BySymbolDesc = 5,
        ByDirectionAsk = 6,
        ByDirectionDesc = 7
    }

    public class TradesFilter : PagingFilter
    {
        public Guid InvestmentProgramId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Symbol { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TradeSorting Sorting { get; set; }
    }
}
