using PortfolioManager.Models;
using PortfolioManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioManager.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTopStocks()
        {
            var stocks = new StockListViewModel { StockList = new List<EquityStock>
            {
                new EquityStock{ Symbol= "MSFT", OriginalPrice=73.9m},
                new EquityStock{ Symbol="AMD", OriginalPrice=13.5m}
            }
            };

            return View(stocks);
        }
    }
}