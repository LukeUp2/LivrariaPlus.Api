using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Responses;
using LivrariaPlus.Api.Data.Repositories;
using LivrariaPlus.Api.Extensions;

namespace LivrariaPlus.Api.UseCases.Books.GetById
{
    public class GetBookByIdUseCase
    {
        private readonly BookRepository _bookRepository;

        public GetBookByIdUseCase(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponseJson?> Execute(Guid bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);

            if (book == null)
            {
                return null;
            }

            return book.ToResponseJson();
        }
    }
}