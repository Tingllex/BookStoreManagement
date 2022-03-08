using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class TransactionsUseCase : ITransactionsUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IGetBookByIdUseCase getBookByIdUseCase;

        public TransactionsUseCase(ITransactionsRepository transactionsRepository, IGetBookByIdUseCase getBookByIdUseCase)
        {
            this.transactionsRepository = transactionsRepository;
            this.getBookByIdUseCase = getBookByIdUseCase;
        }

        public void Execute(int bookId, string employeeFullName, int quantity)
        {
            var book = getBookByIdUseCase.Execute(bookId);
            transactionsRepository.Save(bookId, book.Title, employeeFullName, book.Price.Value, quantity, book.Quantity.Value);
        }
    }
}
