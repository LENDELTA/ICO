using System;
using LENDELTA.DataModel.Enums;

namespace LENDELTA.Core.ViewModels.Trades.Interfaces
{
    public interface IMetaTrader5Order : IBaseOrder
    {
        DateTime? Date { get; set; }
        decimal? Price { get; set; }
        TradeEntryType? Entry { get; set; }
    }
}
