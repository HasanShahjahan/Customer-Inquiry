using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TransactionService.Customer.WebApi.ModelValidators
{
    public class CustomerValidator : AbstractValidator<TransactionService.Customer.Service.Models.Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.customerID)
                .LessThanOrEqualTo(10)
                .WithMessage("The Customer ID cannot be more than 10 digits.")
                .Must(CustomerID)
                .WithMessage("Invalid Customer ID");
        }
        private bool CustomerID(long CustomerID)
        {
            Regex regex = new Regex(@"^\d$");

            if (CustomerID != null)
            {
                if (regex.IsMatch(CustomerID.ToString()))
                {
                    return false;
                }

            }
            return false;
        }
    }
}