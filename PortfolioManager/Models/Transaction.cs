using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Transaction
    {

        [Required]
        public string Symbol { get; set; }
        [Required]
        [MinimumBalance]
        public int Quantity { get; set; }
        [Required]
        public int PortfolioId { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Key]
        [Required]
        public int TransactionId { get; set; }
    }
}