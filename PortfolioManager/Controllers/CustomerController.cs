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

        public ActionResult New()
        {
            return View("CustomerEditForm");
        }

        public ActionResult Edit(int id)
        {
            var customer = _content.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer.Equals(null))
                return HttpNotFound();

            return View("CustomerEditForm",customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerEditForm");
            }
            if(customer.CustomerId == 0)
            {
                customer.CustomerPortfolio = new Portfolio();
                customer.CustomerPortfolio.CustomerId = customer.CustomerId;
                customer.CustomerPortfolio.PortfolioId = customer.CustomerId;
                _content.Customers.Add(customer);
            }
            else
            {
                var CustomerInDb = _content.Customers.Single(c => c.CustomerId == customer.CustomerId);
                CustomerInDb.CustomerBalance = customer.CustomerBalance;
                CustomerInDb.CustomerNumber = customer.CustomerNumber;
            }
            _content.SaveChanges();
            return RedirectToAction("CustomerList", "Customer");
        }

    }
}