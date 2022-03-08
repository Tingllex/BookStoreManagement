using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string employeeFullName);
    }
}