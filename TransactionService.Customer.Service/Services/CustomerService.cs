using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionService.Customer.Data.EntityDataModel;


namespace TransactionService.Customer.Service.Services
{
    public class CustomerService : ICustomerService
    {
        #region DbContext
        private TransactionServiceEntities db = new TransactionServiceEntities();
        #endregion

        #region Service Implementation
        public Data.EntityDataModel.Customer GetCustomer(string email)
        {
            throw new NotImplementedException();
        }

        public Data.EntityDataModel.Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Data.EntityDataModel.Customer GetCustomer(int customerId, string email)
        {
            throw new NotImplementedException();
        }

        public List<Data.EntityDataModel.Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }
        #endregion
    }
}