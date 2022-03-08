using CoreBusiness;

namespace UseCases
{
    public interface IGetBookByIdUseCase
    {
        Book Execute(int bookId);
    }
}