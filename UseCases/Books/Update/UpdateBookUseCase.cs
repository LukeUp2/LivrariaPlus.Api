using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Requests;
using LivrariaPlus.Api.Communication.Responses;

namespace LivrariaPlus.Api.UseCases.Update
{
    public class UpdateBookUseCase
    {
        public Task<BookResponseJson> Execute(UpdateBookRequestJson request, Guid bookId)
        {
            throw new NotImplementedException();
        }
    }
}