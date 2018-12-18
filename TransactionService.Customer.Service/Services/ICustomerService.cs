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
        List<TransactionService.Customer.Data.Customer> GetCustomers();
        TransactionService.Customer.Data.Customer GetCustomer(int customerId);
        TransactionService.Customer.Data.Customer GetCustomer(string email);
        TransactionService.Customer.Data.Customer GetCustomer(int customerId,string email);
    }
}
