using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionService.Customer.Data;
using TransactionService.Customer.Service.Models;

namespace TransactionService.Customer.Service.Services
{
    public class CustomerService : ICustomerService
    {
        #region DbContext
        private TransactionServiceEntities db = new TransactionServiceEntities();
        #endregion

        #region Service Implementation
        public Models.Customer GetCustomer(long? customerId, string email)
        {
            var data = GetCustomerInformation(customerId, email);
            if (data != null) data.transactions = GetTransactionHistory(data.customerID);
            return data;
        }
        #endregion
        private Models.Customer GetCustomerInformation(long? customerId, string email)
        {
            var query = db.Customers.Select(f => f);
            if (customerId != null && string.IsNullOrEmpty(email)) query = query.Where(f => f.customer_id == customerId);
            if (customerId == null && !string.IsNullOrEmpty(email)) query = query.Where(f => f.contact_email == email);
            if (customerId != null && !string.IsNullOrEmpty(email)) query = query.Where(f => f.customer_id == customerId && f.contact_email == email);
            var results = query.Select(u => new Models.Customer
            {
                customerID = u.customer_id,
                name = u.customer_name,
                email = u.contact_email,
                mobile = u.mobile_no.ToString()
            }).FirstOrDefault();
            return results;
        }
        private List<Models.Transaction> GetTransactionHistory(long? customerId)
        {
            var query = db.Transactions.Select(f => f);
            query = query.Where(f => f.customer_id == customerId);
            var results = query.Select(u => new Models.Transaction
            {
                id = u.transaction_id,
                date = u.transaction_date,
                amount = u.amount,
                currency = u.currency_code,
                status = u.status
            }).ToList();
            return results;
        }
    }
}