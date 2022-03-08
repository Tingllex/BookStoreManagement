using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class EditGenreUseCase : IEditGenreUseCase
    {
        private readonly IGenreRepository genreRepository;
        public EditGenreUseCase(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Execute(Genre genre)
        {
            genreRepository.EditGenre(genre);
        }
    }
}
