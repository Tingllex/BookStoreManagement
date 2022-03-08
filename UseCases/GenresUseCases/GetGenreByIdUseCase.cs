using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetGenreByIdUseCase : IGetGenreByIdUseCase
    {
        private readonly IGenreRepository genreRepository;
        public GetGenreByIdUseCase(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public Genre Execute(int genreId)
        {
            return genreRepository.GetGenreById(genreId);
        }
    }
}
