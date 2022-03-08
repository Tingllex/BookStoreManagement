namespace UseCases
{
    public interface ITransactionsUseCase
    {
        void Execute(int bookId, string employeeFullName, int quantity);
    }
}