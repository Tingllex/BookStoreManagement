using System;
using System.Collections.Generic;
using System.Text;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using System.Linq;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionsRepository
    {
        private readonly List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string employeeFullName)
        {
            if(string.IsNullOrWhiteSpace(employeeFullName))
            {
                return transactions;
            }
            else
            {
                return transactions.Where(t => string.Equals(t.EmployeeFullName, employeeFullName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Save(int bookId, string title, string employeeFullName, double price, int quantity, int quantityBefore)
        {
            int transactionId = 0;
            if (transactions.Count >= 1 && transactions != null)
            {
                var maxId = transactions.Max(t => t.TransactionId);
                transactionId = maxId + 1;
            }
            else
            {
                transactionId = 1;
            }
            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                BookId = bookId,
                Title = title,
                EmployeeFullName = employeeFullName,
                Price = price,
                Quantity = quantity,
                QuantityBefore = quantityBefore
            });
        }
    }
}
