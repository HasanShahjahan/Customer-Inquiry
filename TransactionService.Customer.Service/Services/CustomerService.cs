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
        public Models.Customer GetCustomer(string email)
        {
            var data = (from customer in db.Customers
                        join transaction in db.Transactions on customer.transaction_id equals transaction.transaction_id into transactionInformation
                        from transaction in transactionInformation.DefaultIfEmpty()
                        where customer.contact_email == email
                        select new Models.Customer
                        {
                            customerID = customer.customer_id,
                            name = customer.customer_name,
                            email = customer.contact_email
                        }).FirstOrDefault();

            return data;
        }
        public Models.Customer GetCustomer(long customerId)
        {
            var data = (from customer in db.Customers
                        join transaction in db.Transactions on customer.transaction_id equals transaction.transaction_id into transactionInformation
                        from transaction in transactionInformation.DefaultIfEmpty()
                        where customer.customer_id == customerId
                        select new Models.Customer
                        {
                            customerID = customer.customer_id,
                            name = customer.customer_name,
                            email = customer.contact_email
                        }).FirstOrDefault();

            return data;
        }
        public Models.Customer GetCustomer(long customerId, string email)
        {
            var data = (from customer in db.Customers
                        join transaction in db.Transactions on customer.transaction_id equals transaction.transaction_id into transactionInformation
                        from transaction in transactionInformation.DefaultIfEmpty()
                        where customer.customer_id == customerId && customer.contact_email == email
                        select new Models.Customer
                        {
                            customerID = customer.customer_id,
                            name = customer.customer_name,
                            email = customer.contact_email
                        }).FirstOrDefault();

            return data;
        }
        #endregion
    }
}