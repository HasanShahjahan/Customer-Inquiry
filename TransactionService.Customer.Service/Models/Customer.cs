using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionService.Customer.Service.Models
{
    
    public class Customer 
    {
        public long customerID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public List<Transaction> transactions { get; set; }
        public Customer()
        {
            transactions = new List<Transaction>();
        }
    }
}