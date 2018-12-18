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
        TransactionService.Customer.Service.Models.Customer GetCustomer(long customerId);
        TransactionService.Customer.Service.Models.Customer GetCustomer(string email);
        TransactionService.Customer.Service.Models.Customer GetCustomer(long customerId,string email);
    }
}
