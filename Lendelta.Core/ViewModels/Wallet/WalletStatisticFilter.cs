using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Wallet
{
    public class WalletStatisticFilter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public WalletTxType? Type { get; set; }

        public bool IsFull { get; set; }
    }
}
