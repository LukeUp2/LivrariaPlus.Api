using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Exceptions;
using LivrariaPlus.Api.Communication.Requests;
using LivrariaPlus.Api.Communication.Responses;
using LivrariaPlus.Api.Data.Repositories;
using LivrariaPlus.Api.Extensions;
using LivrariaPlus.Api.UseCases.Books.Update;

namespace LivrariaPlus.Api.UseCases.Update
{
    public class UpdateBookUseCase
    {
        private readonly BookRepository _bookRepository;
        private readonly UnitOfWork _unitOfWork;

        public UpdateBookUseCase(BookRepository bookRepository, UnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookResponseJson> Execute(UpdateBookRequestJson request, Guid bookId)
        {
            Validate(request);

            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book is null)
            {
                throw new ErrorOnValidationException(["Book not found."]);
            }

            if (request.Title is not null || request.Author is not null)
            {
                var titleToCheck = request.Title ?? book.Title;
                var authorToCheck = request.Author ?? book.Author;

                var existsAnotherBookWithSameTitleAndAuthor = await _bookRepository.ExistsByTitleAndAuthorAsync(titleToCheck, authorToCheck);
                if (existsAnotherBookWithSameTitleAndAuthor)
                {
                    throw new ErrorOnValidationException(["Another book with the same title and author already exists."]);
                }
            }

            if (request.Title is not null) book.Title = request.Title;
            if (request.Author is not null) book.Author = request.Author;
            if (request.Price is not null) book.Price = request.Price.Value;
            if (request.Genre is not null) book.Genre = (Enuns.BookGenre)request.Genre;
            if (request.Stock is not null) book.Stock = request.Stock.Value;

            book.UpdatedAt = DateTime.UtcNow;

            await _bookRepository.UpdateAsync(book);
            await _unitOfWork.CommitAsync();

            return book.ToResponseJson();

        }

        private static void Validate(UpdateBookRequestJson request)
        {
            var result = new UpdateBookUseCaseValidator().Validate(request);
            if (result.IsValid.IsFalse())
            {
                throw new ErrorOnValidationException(result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }
    }
}