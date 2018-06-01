using LENDELTA.Core.ViewModels.Common;
using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LENDELTA.Core.ViewModels.Wallet
{
    public class TransactionsFilter : PagingFilter
    {
        public Guid? InvestmentProgramId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public WalletTxType Type { get; set; }
    }
}
