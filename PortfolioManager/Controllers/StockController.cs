using PortfolioManager.Models;
using PortfolioManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioManager.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext _content;

        public StockController()
        {
            _content = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }
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

        public ActionResult PortfolioList()
        {
            var customers = _content.Customers.Include(x=>x.CustomerPortfolio);
            return View(customers);
        }

        public ActionResult StockList(int id)
        {
            var customer = _content.Customers.Single(x => x.CustomerId == id);
            return View(customer.CustomerPortfolio);
        }
    }
}