using System;
using Microsoft.EntityFrameworkCore;
using CoreBusiness;

namespace Plugins.DataStore.SQLdatabase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithOne(b => b.Genres)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<Genre>().HasData(
                    new Genre { GenreId = 1, Name = "horror", Note = "fiction, not for kids" },
                    new Genre { GenreId = 2, Name = "adventure", Note = "ficiton" },
                    new Genre { GenreId = 3, Name = "learning", Note = "nonfiction" }
                );

            modelBuilder.Entity<Book>().HasData(
                    new Book { BookId = 1, Title = "c#", PublicationYear = 2015, Price = 16.99, Quantity = 10, GenreId = 3 },
                    new Book { BookId = 2, Title = "podstawy python", PublicationYear = 2020, Price = 25.99, Quantity = 40, GenreId = 3 },
                    new Book { BookId = 3, Title = "test1", PublicationYear = 2022, Price = 20, Quantity = 200, GenreId = 1 }
                );
        }
        

    }
}
