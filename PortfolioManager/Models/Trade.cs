﻿using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class Trade : ITrade
    {

        [Required]
        public string Symbol { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int PortfolioId { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        [Required]
        public decimal BuyPrice { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Trade type not valid")]
        public String TradeType { get; set; }
        [Key]
        [Required]
        public int TradeId { get; set; }

    }
}