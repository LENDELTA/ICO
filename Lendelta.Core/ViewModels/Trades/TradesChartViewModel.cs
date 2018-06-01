using System;
using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Trades
{
    public class TradesChartViewModel
    {
        public List<TradeChart> Chart { get; set; }
    }

    public class TradeChart
    {
        public DateTime Date { get; set; }
        public decimal Profit { get; set; }
    }
}
