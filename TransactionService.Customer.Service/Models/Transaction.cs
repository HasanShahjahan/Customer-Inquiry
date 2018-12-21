using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionService.Customer.Service.Models
{
    public class Transaction
    {
        public long id { get; set; }
        public string date { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }

    }
}