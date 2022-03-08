using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetBookByIdUseCase : IGetBookByIdUseCase
    {
        private readonly IBookRepository bookRepository;
        public GetBookByIdUseCase(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book Execute(int bookId)
        {
            return bookRepository.GetBookById(bookId);
        }
    }
}
