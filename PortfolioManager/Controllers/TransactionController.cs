using PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PortfolioManager.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _content;

        public TransactionController()
        {
            _content = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _content.Dispose();
        }
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddTransactionForm",new { id = transaction.PortfolioId });
            }
            _content.Transactions.Add(transaction);
            _content.SaveChanges();

            return View("PortfolioList");
        }
        public ActionResult AddTransactionForm(int id)
        {
            ViewBag.PortfolioId = id;
            return View();
        }


        public ActionResult PortfolioList()
        {
            var customers = _content.Customers.Include(x => x.CustomerPortfolio);
            return View(customers);
        }
    }
}