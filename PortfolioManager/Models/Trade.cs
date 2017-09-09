using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Trade : ITrade
    {
        public string Symbol { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}