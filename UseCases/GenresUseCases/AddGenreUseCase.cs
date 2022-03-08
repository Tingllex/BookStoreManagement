using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class AddGenreUseCase : IAddGenreUseCase
    {
        private readonly IGenreRepository genreRepository;
        public AddGenreUseCase(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public void Execute(Genre genre)
        {
            genreRepository.AddGenre(genre);
        }
    }
}
