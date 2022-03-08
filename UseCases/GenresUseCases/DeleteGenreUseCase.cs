using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class DeleteGenreUseCase : IDeleteGenreUseCase
    {
        private readonly IGenreRepository genreRepository;
        public DeleteGenreUseCase(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Delete(int genreId)
        {
            genreRepository.DeleteGenre(genreId);
        }
    }
}
