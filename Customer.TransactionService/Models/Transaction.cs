using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer.TransactionService.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode{ get; set; }
        public string Status { get; set; }
    }
}