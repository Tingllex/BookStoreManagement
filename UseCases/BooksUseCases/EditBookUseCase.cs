using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditBookUseCase : IEditBookUseCase
    {
        private readonly IBookRepository bookRepository;
        public EditBookUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Execute(Book book)
        {
            bookRepository.EditBook(book);
        }
    }
}
