using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewGenresUseCase : IViewGenresUseCase
    {
        private readonly IGenreRepository genreRepository;

        public ViewGenresUseCase(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IEnumerable<Genre> Execute()
        {
            return genreRepository.GetGenres();
        }
    }
}
