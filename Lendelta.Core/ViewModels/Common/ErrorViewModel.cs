using System.Collections.Generic;
using LENDELTA.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Common
{
    public class ErrorViewModel
    {
        public IEnumerable<ErrorMessage> Errors { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorCodes Code { get; set; }
    }
}
