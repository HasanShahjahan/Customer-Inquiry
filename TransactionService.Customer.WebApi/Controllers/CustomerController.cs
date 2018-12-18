using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransactionService.Customer.Service.Services;

namespace TransactionService.Customer.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        #region Global Members
        private TransactionService.Customer.Service.Services.ICustomerService _customerService = new CustomerService();
        #endregion

        #region Public Methods
        public List<TransactionService.Customer.Data.Customer> Get()
        {
            List<TransactionService.Customer.Data.Customer> customers = null;
            try
            {
                customers = _customerService.GetCustomers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return customers;
        }
        public TransactionService.Customer.Data.Customer Get(int customerId)
        {
            TransactionService.Customer.Data.Customer customer;
            try
            {
                customer = _customerService.GetCustomer(customerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        #endregion
    }
}
