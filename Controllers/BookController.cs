using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Requests;
using LivrariaPlus.Api.UseCases.Books.Create;
using LivrariaPlus.Api.UseCases.Books.Delete;
using LivrariaPlus.Api.UseCases.Books.GetById;
using LivrariaPlus.Api.UseCases.Books.ListAll;
using LivrariaPlus.Api.UseCases.Update;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaPlus.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListAll([FromServices] ListAllBooksUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpGet("{bookId:guid}")]
        public async Task<IActionResult> GetById([FromServices] GetBookByIdUseCase useCase, [FromRoute] Guid bookId)
        {
            var result = await useCase.Execute(bookId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateBookUseCase useCase, [FromBody] CreateBookRequestJson request)
        {
            await useCase.Execute(request);
            return Created(string.Empty, null);
        }

        [HttpPut("{bookId:guid}")]
        public async Task<IActionResult> Update([FromServices] UpdateBookUseCase useCase, [FromBody] UpdateBookRequestJson request, [FromRoute] Guid bookId)
        {
            var result = await useCase.Execute(request, bookId);
            return Ok(result);
        }

        [HttpDelete("{bookId:guid}")]
        public async Task<IActionResult> Delete([FromServices] DeleteBookUseCase useCase, [FromRoute] Guid bookId)
        {
            await useCase.Execute(bookId);
            return Ok();
        }
    }
}