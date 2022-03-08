using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;

        public GetTransactionsUseCase(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public IEnumerable<Transaction> Execute(string employeeFullName)
        {
            return transactionsRepository.Get(employeeFullName);
        }
    }
}
