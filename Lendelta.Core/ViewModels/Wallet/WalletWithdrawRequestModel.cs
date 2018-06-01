using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace LENDELTA.Core.ViewModels.Wallet
{
    public class WalletWithdrawRequestModel
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string BlockchainAddress { get; set; }
    }
}
