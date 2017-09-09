using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class CommodityStock : IStock
    {
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public int CustomerId { get; set; }

        public decimal GetCurrentQuote()
        {
            throw new NotImplementedException();
        }
    }
}