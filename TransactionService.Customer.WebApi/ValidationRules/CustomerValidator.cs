using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TransactionService.Customer.WebApi.ValidationRules
{
    public static class CustomerValidator
    {
        
        internal static bool IsValidationRules(long? customerId, string email, out string errorMessage)
        {
            errorMessage = string.Empty;
            Regex regexCustomerId = new Regex(@"^[0-9]+$");
            Regex regexEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (customerId == null && string.IsNullOrEmpty(email))
            {
                errorMessage = "No inquiry criteria";
                return false;
            }
            if (customerId != null && string.IsNullOrEmpty(email))
            {
                if (!regexCustomerId.IsMatch(customerId.ToString())) errorMessage = "Invalid Customer Id";
                if (customerId.ToString().Length > 10) errorMessage = "Invalid Customer Id";
                if (string.IsNullOrEmpty(errorMessage)) return true;
                return false;
            }
            if (customerId == null && !string.IsNullOrEmpty(email))
            {
                if (!regexEmail.IsMatch(email)) errorMessage = "Invalid Email";
                if (email.Length > 25) errorMessage = "Invalid Email";
                if (string.IsNullOrEmpty(errorMessage)) return true;
                return false;
            }
            if (customerId != null && !string.IsNullOrEmpty(email))
            {
                if (!regexCustomerId.IsMatch(customerId.ToString())) errorMessage = "Invalid Customer Id";
                if (customerId.ToString().Length > 10) errorMessage += "Invalid Customer Id";
                if (!regexEmail.IsMatch(email)) errorMessage += "Invalid Email";
                if (email.Length > 25) errorMessage += "Invalid Email";
                if (string.IsNullOrEmpty(errorMessage)) return true;
                return false;
            }
            return true;
        }
    }
}