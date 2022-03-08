using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SellBookUseCase : ISellBookUseCase
    {
        private readonly IBookRepository bookRepository;
        private readonly ITransactionsUseCase transactionsUseCase;

        public SellBookUseCase(IBookRepository bookRepository, ITransactionsUseCase transactionsUseCase)
        {
            this.bookRepository = bookRepository;
            this.transactionsUseCase = transactionsUseCase;
        }

        public void Execute(int bookId, string employeeFullName, int quantity)
        {
            var book = bookRepository.GetBookById(bookId);
            if (book == null) return;
            transactionsUseCase.Execute(bookId, employeeFullName, quantity);
            book.Quantity -= quantity;
            bookRepository.EditBook(book);
        }
    }
}
