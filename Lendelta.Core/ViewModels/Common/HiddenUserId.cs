using Newtonsoft.Json;
using System;

namespace LENDELTA.Core.ViewModels.Common
{
    public class HiddenUserId
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
