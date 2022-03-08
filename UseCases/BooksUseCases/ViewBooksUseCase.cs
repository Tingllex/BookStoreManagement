using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewBooksUseCase : IViewBooksUseCase
    {
        private readonly IBookRepository bookRepository;
        public ViewBooksUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IEnumerable<Book> Execute()
        {
            return bookRepository.GetBooks();
        }
    }
}
