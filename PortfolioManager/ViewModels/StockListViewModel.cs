using PortfolioManager.Models;
using PortfolioManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManager.ViewModels
{
    public class StockListViewModel
    {
        public List<EquityStock> StockList { get; set; }
    }
}