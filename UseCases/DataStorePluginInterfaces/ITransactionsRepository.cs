using System;
using System.Collections.Generic;
using System.Text;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionsRepository
    {
        public IEnumerable<Transaction> Get(string employeeFullName);
        public void Save(int bookId, string title, string employeeFullName, double price, int quantity, int quantityBefore);
    }
}
