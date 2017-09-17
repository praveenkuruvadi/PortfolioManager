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
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(255)]
        [Display(Name ="Full Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name ="Balance")]
        public decimal CustomerBalance { get; set; }
        [Display(Name ="Phone Number")]
        public string CustomerNumber { get; set; }
        

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