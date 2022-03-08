namespace UseCases
{
    public interface ISellBookUseCase
    {
        void Execute(int bookId, string employeeFullName, int quantity);
    }
}