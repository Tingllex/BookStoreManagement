using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLdatabase
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext dbContext;
        public GenreRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddGenre(Genre genre)
        {
            dbContext.Genres.Add(genre);
            dbContext.SaveChanges();
        }

        public void DeleteGenre(int genreId)
        {
            var genre = dbContext.Genres.Find(genreId);
            if (genre == null) return;
            dbContext.Genres.Remove(genre);
            dbContext.SaveChanges();
        }

        public void EditGenre(Genre genre)
        {
            var genreToEdit = dbContext.Genres.Find(genre.GenreId);
            genreToEdit.Name = genre.Name;
            genreToEdit.Note = genre.Note;
            dbContext.SaveChanges();
        }

        public Genre GetGenreById(int genreId)
        {
            return dbContext.Genres.Find(genreId);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return dbContext.Genres.ToList();
        }
    }
}
