using PortfolioManager.Models;
using PortfolioManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioManager.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerList()
        {
            var customers = new CustomerListViewModel
            {
                CustomerList = new List<Customer>
            {
                new Customer{ CustomerId = 1, CustomerName = "Customer 1", CustomerBalance = 0},
                new Customer{ CustomerId = 2, CustomerName = "Customer 2", CustomerBalance = 0}
            }
            };
            return View(customers);
        }

    }
}