using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Portfolio : IPortfolio
    {
        public List<CommodityStock> CommodityStockList { get; set; }
        public List<EquityStock> EquityStockList { get; set; }

        public decimal GetPortfolioValue()
        {
            return 0;
        }

        public List<ITrade> GetTradeHistory()
        {
            throw new NotImplementedException();
        }

        public void UpdateTrade(ITrade Trade)
        {
            throw new NotImplementedException();
        }
    }
}