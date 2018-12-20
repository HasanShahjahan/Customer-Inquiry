using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransactionService.Customer.Service.Services;
using TransactionService.Customer.WebApi.ValidationRules;

namespace TransactionService.Customer.WebApi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        #region Global Members
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private TransactionService.Customer.Service.Services.ICustomerService _customerService = new CustomerService();
        string errorMessage = string.Empty;
        #endregion

        #region Public Methods
        [Route("Details")]
        public HttpResponseMessage Get(long? customerId, string email)
        {

            if (CustomerValidator.IsValidationRules(customerId, email, out errorMessage))
            {
                logger.Info("Inquery with Customer Id :" + customerId +" and Email address : " + email);
                var customer = _customerService.GetCustomer(customerId, email);
                if (customer != null) return Request.CreateResponse(HttpStatusCode.OK, customer);
                logger.Info("No Customer Found.");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Customer Found");

            }
            else
            {
                logger.Trace(errorMessage);
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, errorMessage);
            }
        }

        #endregion

        #region Disposal
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion
    }
}
