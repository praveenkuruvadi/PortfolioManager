using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Customer : ICustomer
    {
        
        public Portfolio CustomerPortfolio { get; set; }
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public decimal CustomerBalance { get; set; }
        public string CustomerNumber { get; set; }
        public int PortfolioId { get; set; }

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