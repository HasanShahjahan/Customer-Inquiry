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
            var data = (from customer in db.Customers
                        join transaction in db.Transactions on customer.customer_id equals transaction.customer_id into transactionInformation
                        from transaction in transactionInformation.DefaultIfEmpty()
                        where customer.customer_id == customerId && customer.contact_email == email
                        select new Models.Customer
                        {
                            customerID = customer.customer_id,
                            name = customer.customer_name,
                            email = customer.contact_email,
                            mobile = customer.mobile_no.ToString()
                            
                        }).FirstOrDefault();

            if(data !=null) data.transactions = GetTransactionHistory(customerId,email);
            return data;
        }
        #endregion

        private List<Models.Transaction> GetTransactionHistory(long? customerId, string email)
        {
            List<Models.Transaction> data = null; 
            try
            {
                     data = (from transaction in db.Transactions
                            join customer in db.Customers on transaction.customer_id equals customer.customer_id into transactionInformation
                            where transaction.customer_id == customerId
                            select new Models.Transaction
                            {
                                id = transaction.customer_id,
                                date = transaction.transaction_date,
                                amount = transaction.amount,
                                currency = transaction.currency_code,
                                status = transaction.status
                            }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return data;
        }
    }
}