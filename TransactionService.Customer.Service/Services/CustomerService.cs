using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionService.Customer.Data;


namespace TransactionService.Customer.Service.Services
{
    public class CustomerService : ICustomerService
    {
        #region DbContext
        private TransactionServiceEntities db = new TransactionServiceEntities();
        #endregion

        #region Service Implementation
        public TransactionService.Customer.Data.Customer GetCustomer(string email)
        {
            throw new NotImplementedException();
        }

        public TransactionService.Customer.Data.Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public TransactionService.Customer.Data.Customer GetCustomer(int customerId, string email)
        {
            throw new NotImplementedException();
        }

        public List<TransactionService.Customer.Data.Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }
        #endregion
    }
}