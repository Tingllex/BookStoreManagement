using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLdatabase
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext dbContext;
        public BookRepository (DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddBook(Book book)
        {
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = dbContext.Books.Find(bookId);
            if (book == null) return;
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public void EditBook(Book book)
        {
            var bookToEdit = dbContext.Books.Find(book.BookId);
            bookToEdit.GenreId = book.GenreId;
            bookToEdit.Title = book.Title;
            bookToEdit.PublicationYear = book.PublicationYear;
            bookToEdit.Price = book.Price;
            bookToEdit.Quantity = book.Quantity;
            dbContext.SaveChanges();
        }

        public Book GetBookById(int bookId)
        {
            return dbContext.Books.Find(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return dbContext.Books.ToList();
        }

        public IEnumerable<Book> GetBooksByGenreId(int genreId)
        {
            return dbContext.Books.Where(b => b.GenreId == genreId).ToList();
        }
    }
}
