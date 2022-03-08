using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLdatabase
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly DatabaseContext dbContext;
        public TransactionsRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Transaction> Get(string employeeFullName)
        {
            if (string.IsNullOrWhiteSpace(employeeFullName))
            {
                return dbContext.Transactions;
            }
            else
            {
                return dbContext.Transactions.Where(t => t.EmployeeFullName.ToLower() == employeeFullName.ToLower());
            }
        }

        public void Save(int bookId, string title, string employeeFullName, double price, int quantity, int quantityBefore)
        {
            var transaction = new Transaction
            {
                BookId = bookId,
                Title = title,
                EmployeeFullName = employeeFullName,
                Price = price,
                Quantity = quantity,
                QuantityBefore = quantityBefore
            };
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();
        }
    }
}
