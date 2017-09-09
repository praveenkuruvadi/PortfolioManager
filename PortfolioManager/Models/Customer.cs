using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Customer : ICustomer
    {
        public Portfolio CustomerPortfolio { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal CustomerBalance { get; set; }

        public decimal GetAssetsValue()
        {
            return this.CustomerPortfolio.GetPortfolioValue();
        }

        List<ITrade> ICustomer.GetTradeHistory()
        {
            return this.CustomerPortfolio.GetTradeHistory();
        }
    }
}