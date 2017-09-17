using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Portfolio : IPortfolio
    {
        public ICollection<Transaction> TransactionHistory { get; set; }
        public ICollection<CommodityStock> CommodityStockList { get; set; }
        public ICollection<EquityStock> EquityStockList { get; set; }

        public Portfolio()
        {
            TransactionHistory = new List<Transaction>();
            CommodityStockList = new List<CommodityStock>();
            EquityStockList = new List<EquityStock>();
        }
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