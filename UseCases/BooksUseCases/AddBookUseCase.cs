using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddBookUseCase : IAddBookUseCase
    {
        private readonly IBookRepository bookRepository;
        public AddBookUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Execute(Book book)
        {
            bookRepository.AddBook(book);
        }
    }
}
