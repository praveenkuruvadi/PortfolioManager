using PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortfolioManager.Controllers.Api
{
    public class TransactionController : ApiController
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

        // GET /api/transaction
        public IHttpActionResult GetTransaction()
        {
            return Ok(_content.Transactions.OrderBy(x => x.TimeStamp).ToList());
        }
        // GET /api/transaction/1
        public IHttpActionResult GetTransaction(int id)
        {
            var transactions = _content.Transactions.Where(x => x.PortfolioId == id).ToList();

            if (transactions == null)
                return NotFound();

            return Ok(transactions);
        }

        // POST /api/transaction
        [HttpPost]
        public IHttpActionResult AddTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _content.Transactions.Add(transaction);
            _content.SaveChanges();
            return Ok(transaction);
        }
    }
}
