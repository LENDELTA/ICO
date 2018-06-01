using GenesisVision.Core.ViewModels.Account;
using GenesisVision.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace GenesisVision.Core.ViewModels.Investment
{
    public class InvestmentProgramBuyToken
    {
        public Guid Id { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public ProfilePublicViewModel Manager { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public decimal GvtRate { get; set; }
        public decimal GvtWalletAmount { get; set; }
        public int PeriodDuration { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
        public decimal AvailableInvestments { get; set; }
        public Guid RateCacheId { get; set; }
        public decimal ManagerFee { get; set; }
        public decimal GVFee { get; set; }
        
    }
}
