using LENDELTA.Core.ViewModels.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace LENDELTA.Core.ViewModels.Investment
{
    public class Invest : HiddenUserId
    {
        [Required]
        public Guid InvestmentProgramId { get; set; }

        private decimal AmountOrig { get; set; }

        [Required]
        public decimal Amount
        {
            get => Math.Round(AmountOrig, 8);
            set => AmountOrig = value;
        }

        //[Required]
        //public Guid RateCacheId { get; set; }
    }
}
