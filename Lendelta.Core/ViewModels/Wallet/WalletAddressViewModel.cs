using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Wallet
{
    public class WalletAddressViewModel
    {
        public string Address { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
    }
}
