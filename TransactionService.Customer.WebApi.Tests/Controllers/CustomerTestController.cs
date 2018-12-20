using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionService.Customer.WebApi.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace TransactionService.Customer.WebApi.Tests.Controllers
{
    
    [TestClass]
    public class CustomerTestController
    {
        [TestMethod]
        public void CustomerGetByCustomerIdAndEmail()
        {
            //Arrange
            var controller = new CustomerController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Get(1000000001,"hasan.shahjahan@gmail.com");

            // Assert
            TransactionService.Customer.Service.Models.Customer customer;
            Assert.IsTrue(response.TryGetContentValue<TransactionService.Customer.Service.Models.Customer>(out customer));
            Assert.AreEqual(1000000001, customer.customerID);
            Assert.AreEqual("hasan.shahjahan@gmail.com", customer.email);

        }
    }
}
