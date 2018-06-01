using System;
using System.Collections.Generic;

namespace GenesisVision.Core.ViewModels.Wallet
{
    public class WalletStatistic
    {
        public IEnumerable<DateChart> Chart { get; set; }
    }

    public class DateChart
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
