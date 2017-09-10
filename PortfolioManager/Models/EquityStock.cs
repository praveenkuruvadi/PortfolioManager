using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class EquityStock : IStock
    {
        [Required]
        public string Symbol { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal OriginalPrice { get; set; }
        [Required]
        public int PortfolioId { get; set; }
        [Key]
        public int EntryId { get; set; }

        public decimal GetCurrentQuote()
        {
            throw new NotImplementedException();
        }
    }
}