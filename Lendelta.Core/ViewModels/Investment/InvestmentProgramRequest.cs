﻿using LENDELTA.DataModel.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class InvestmentProgramRequest
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public InvestmentRequestType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public InvestmentRequestStatus Status { get; set; }
        public bool CanCancelRequest { get; set; }
    }
}
