using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewBooksUseCase
    {
        IEnumerable<Book> Execute();
    }
}