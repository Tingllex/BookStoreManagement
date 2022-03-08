using System.Collections.Generic;
using CoreBusiness;

namespace UseCases
{
    public interface IViewBooksByGenreId
    {
        IEnumerable<Book> Execute(int genreId);
    }
}