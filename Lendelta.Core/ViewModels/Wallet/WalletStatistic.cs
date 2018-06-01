using System;
using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Wallet
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
