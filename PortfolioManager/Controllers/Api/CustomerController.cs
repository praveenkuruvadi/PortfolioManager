using PortfolioManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PortfolioManager.Controllers.Api
{
    public class CustomerController : ApiController
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

        // GET /api/customer
        public IHttpActionResult GetCustomer()
        {
            return Ok(_content.Customers.ToList());
        }

        // GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _content.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _content.Customers.Add(customer);
            _content.SaveChanges();
            return Created(new Uri(Request.RequestUri+"/"+customer.CustomerId),customer);
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDb = _content.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _content.Customers.Remove(CustomerInDb);

        }
    }
}
