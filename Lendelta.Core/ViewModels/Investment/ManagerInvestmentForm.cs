using System;
using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class ManagerInvestmentForm
    {
        public Guid Id { get; set; }
        
        public string Logo { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        
        public DateTime StartOfPeriod { get; set; }
        public DateTime EndOfPeriod { get; set; }
        public int PeriodDuration { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Currency Currency { get; set; }
        public decimal GvtRate { get; set; } 
        public Guid RateCacheId { get; set; }
        
        public decimal GvtWalletAmount { get; set; }
    }
}
