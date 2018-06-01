using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GenesisVision.Core.ViewModels.Manager
{
    public enum ManagerDashboardProgramsType
    {
        All = 0,
        Active = 1,
        Finished = 2,
        Pending = 3
    }

    public class ManagerDashboardProgramsFilter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ManagerDashboardProgramsType Type { get; set; }
    }
}
