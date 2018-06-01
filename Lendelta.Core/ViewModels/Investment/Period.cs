using System;
using System.Collections.Generic;
using LENDELTA.DataModel.Enums;
using LENDELTA.DataModel.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class Period
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PeriodStatus Status { get; set; }
        public decimal StartBalance { get; set; }
        public decimal ManagerStartBalance { get; set; }
        public decimal ManagerStartShare { get; set; }
        public PeriodProcessStatus ProcessStatus { get; set; }
        public List<InvestmentProgramRequest> InvestmentRequest { get; set; }
    }
}
