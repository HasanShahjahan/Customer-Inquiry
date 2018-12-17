using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.TransactionService.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public int MobileNo { get; set; }
        public List<Transaction> ListOfTransaction { get; set;}

        public Customer()
        {
            ListOfTransaction = new List<Transaction>();
        }
    }
}