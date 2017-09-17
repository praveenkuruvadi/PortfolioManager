using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortfolioManager.Models
{
    public class MinimumBalance : ValidationAttribute
    {
        private ApplicationDbContext _content;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _content = new ApplicationDbContext();
            var transaction = (Transaction)validationContext.ObjectInstance;
            if (transaction.TransactionType.Equals("Sell"))
                return ValidationResult.Success;
            else if (transaction.Quantity * transaction.Price
                > _content.Customers.Single(x => x.CustomerId == transaction.PortfolioId).CustomerBalance)
                return new ValidationResult("You do not have enough balance");
            else
                return ValidationResult.Success;
        }
    }
}