using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        void AddBook(Book book);
        void EditBook(Book book);
        Book GetBookById(int bookId);
        void DeleteBook(int bookId);
        IEnumerable<Book> GetBooksByGenreId(int genreId);
    }
}
