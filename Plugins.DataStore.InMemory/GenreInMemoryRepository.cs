using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class GenreInMemoryRepository : IGenreRepository
    {
        private readonly List<Genre> genres;

        public GenreInMemoryRepository()
        {
            genres = new List<Genre>()
            {
                new Genre { GenreId = 1, Name = "horror", Note = "fiction, not for kids" },
                new Genre { GenreId = 2, Name = "adventure", Note = "ficiton" },
                new Genre { GenreId = 3, Name = "learning", Note = "nonfiction" },
            };
        }

        public void AddGenre(Genre genre)
        {
            if (genres.Any(g => g.Name.Equals(genre.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (genres.Count >= 1 && genres != null)
            {
                var maxId = genres.Max(g => g.GenreId);
                genre.GenreId = maxId + 1;
            }
            else
            {
                genre.GenreId = 1;
            }
            genres.Add(genre);
        }

        public void EditGenre(Genre genre)
        {
            var genreToUpdate = GetGenreById(genre.GenreId);
            if (genreToUpdate != null)
            {
                genreToUpdate.Name = genre.Name;
                genreToUpdate.Note = genre.Note;
            }
        }

        public Genre GetGenreById(int genreId)
        {
            return genres?.FirstOrDefault(g => g.GenreId == genreId);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return genres;
        }

        public void DeleteGenre(int genreId)
        {
            genres?.Remove(GetGenreById(genreId));
        }
    }
}
