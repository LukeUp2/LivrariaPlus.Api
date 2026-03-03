using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Responses;
using LivrariaPlus.Api.Data.Repositories;
using LivrariaPlus.Api.Extensions.EntityToDTO;

namespace LivrariaPlus.Api.UseCases.Books.ListAll
{
    public class ListAllBooksUseCase
    {
        private readonly BookRepository _bookRepository;
        public ListAllBooksUseCase(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookResponseJson>> Execute()
        {
            var books = await _bookRepository.GetAllAsync();
            var bookList = books.Select(book => book.ToResponseJson()).ToList();

            return bookList;
        }
    }
}