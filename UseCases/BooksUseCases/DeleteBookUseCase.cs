using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteBookUseCase : IDeleteBookUseCase
    {
        private readonly IBookRepository bookRepository;
        public DeleteBookUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Delete(int bookId)
        {
            bookRepository.DeleteBook(bookId);
        }
    }
}
