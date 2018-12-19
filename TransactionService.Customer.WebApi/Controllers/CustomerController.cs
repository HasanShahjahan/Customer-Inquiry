using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Http;
using TransactionService.Customer.Service.Services;
using TransactionService.Customer.WebApi.ValidationRules;

namespace TransactionService.Customer.WebApi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        #region Global Members
        private TransactionService.Customer.Service.Services.ICustomerService _customerService = new CustomerService();
        string errorMessage = string.Empty;
        #endregion

        #region Public Methods
        [Route("Details")]
        public HttpResponseMessage Get(long? customerId,string email)
        {
            if (CustomerValidator.IsValidationRules(customerId, email, out errorMessage))
            {
                var customer = _customerService.GetCustomer(customerId, email);
                if (customer != null) return Request.CreateResponse(HttpStatusCode.OK, customer);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Customer Found");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, errorMessage);
            }
        }

        #endregion

        #region Private Methods
        
        #endregion
    }
}
