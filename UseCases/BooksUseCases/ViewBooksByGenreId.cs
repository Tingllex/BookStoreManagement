using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewBooksByGenreId : IViewBooksByGenreId
    {
        private readonly IBookRepository bookRepository;
        public ViewBooksByGenreId(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IEnumerable<Book> Execute(int genreId)
        {
            return bookRepository.GetBooksByGenreId(genreId);
        }
    }
}
