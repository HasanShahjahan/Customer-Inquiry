using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionService.Customer.Data;

namespace TransactionService.Customer.Service.Services
{
    public interface ICustomerService
    {
        List<TransactionService.Customer.Data.EntityDataModel.Customer> GetCustomers();
        TransactionService.Customer.Data.EntityDataModel.Customer GetCustomer(int customerId);
        TransactionService.Customer.Data.EntityDataModel.Customer GetCustomer(string email);
        TransactionService.Customer.Data.EntityDataModel.Customer GetCustomer(int customerId,string email);
    }
}
