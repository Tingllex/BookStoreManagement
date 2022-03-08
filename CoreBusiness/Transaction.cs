using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBusiness
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string EmployeeFullName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int QuantityBefore { get; set; }
    }
}
