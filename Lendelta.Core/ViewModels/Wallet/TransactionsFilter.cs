using GenesisVision.Core.ViewModels.Common;
using GenesisVision.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace GenesisVision.Core.ViewModels.Wallet
{
    public class TransactionsFilter : PagingFilter
    {
        public Guid? InvestmentProgramId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WalletTxType Type { get; set; }
    }
}
