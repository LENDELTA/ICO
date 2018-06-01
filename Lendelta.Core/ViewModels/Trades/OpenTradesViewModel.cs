using System.Collections.Generic;

namespace LENDELTA.Core.ViewModels.Trades
{
    public class OpenTradesViewModel
    {
        public List<OpenOrderModel> Trades { get; set; }

        public int Total { get; set; }
    }
}
