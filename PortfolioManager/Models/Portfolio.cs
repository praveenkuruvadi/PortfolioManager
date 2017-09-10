using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Portfolio : IPortfolio
    {
        public List<Trade> TradeHistory { get; set; }
        public List<CommodityStock> CommodityStockList { get; set; }
        public List<EquityStock> EquityStockList { get; set; }
        [Key]
        [Required]
        public int PortfolioId { get; set; }
        [Required]
        public int CustomerId { get; set; }

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