using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class BookInMemoryRepository : IBookRepository
    {
        private readonly List<Book> books;

        public BookInMemoryRepository()
        {
            books = new List<Book>()
            {
                new Book { BookId = 1, Title = "c#", PublicationYear = 2015, Price = 16.99, Quantity = 10, GenreId = 3},
                new Book { BookId = 2, Title = "podstawy python", PublicationYear = 2020, Price = 25.99, Quantity = 40, GenreId = 3} ,
                new Book { BookId = 3, Title = "test1", PublicationYear = 2022, Price = 20, Quantity = 200, GenreId = 1},
            };
        }

        public void AddBook(Book book)
        {
            if (books.Any(g => g.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase))) return;
            if (books.Count >= 1 && books != null)
            {
                var maxId = books.Max(g => g.BookId);
                book.BookId = maxId + 1;
            }
            else
            {
                book.BookId = 1;
            }
            books.Add(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        public void EditBook(Book book)
        {
            var bookToUpdate = GetBookById(book.BookId);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.GenreId = book.GenreId;
                bookToUpdate.PublicationYear = book.PublicationYear;
                bookToUpdate.Price = book.Price;
                bookToUpdate.Quantity = book.Quantity;
            }
        }

        public Book GetBookById(int bookId)
        {
            return books?.FirstOrDefault(b => b.BookId == bookId);
        }

        public void DeleteBook(int bookId)
        {
            books?.Remove(GetBookById(bookId));
        }

        public IEnumerable<Book> GetBooksByGenreId(int genreId)
        {
            return books.Where(b => b.GenreId == genreId);
        }
    }
}
