using PortfolioManager.Models;
using PortfolioManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace PortfolioManager.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _content;

        public CustomerController()
        {
            _content = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerList()
        {
            var customers = _content.Customers.Include(x => x.CustomerPortfolio);
            return View(customers);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customerDetail = _content.Customers.SingleOrDefault(x => x.CustomerId.Equals(id));
            return View(customerDetail);
        }

    }
}