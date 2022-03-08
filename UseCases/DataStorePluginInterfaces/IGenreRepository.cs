using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.DataStorePluginInterfaces
{
    public  interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
        void AddGenre(Genre genre);
        void EditGenre(Genre genre);
        Genre GetGenreById(int genreId);
        void DeleteGenre(int genreId);
    }
}
