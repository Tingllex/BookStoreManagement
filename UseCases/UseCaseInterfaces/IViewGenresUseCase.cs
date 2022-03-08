using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewGenresUseCase
    {
        IEnumerable<Genre> Execute();
    }
}