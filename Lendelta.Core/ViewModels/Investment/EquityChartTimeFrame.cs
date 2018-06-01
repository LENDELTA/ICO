using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GenesisVision.Core.ViewModels.Investment
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EquityChartTimeFrame
    {
        Day1,
        Week1,
        Month1,
        Month3,
        Month6,
        Year1,
        All
    }
}
