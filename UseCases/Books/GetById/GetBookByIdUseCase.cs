using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Responses;

namespace LivrariaPlus.Api.UseCases.Books.GetById
{
    public class GetBookByIdUseCase
    {
        public Task<BookResponseJson?> Execute(Guid bookId)
        {
            throw new NotImplementedException();
        }
    }
}