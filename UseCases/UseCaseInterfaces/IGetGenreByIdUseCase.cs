using CoreBusiness;

namespace UseCases
{
    public interface IGetGenreByIdUseCase
    {
        Genre Execute(int genreId);
    }
}