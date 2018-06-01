using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class DashboardFilter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Sorting? Sorting { get; set; }
        public int? EquityChartLength { get; set; }
    }
}
