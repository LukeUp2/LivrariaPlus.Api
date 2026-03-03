using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Exceptions;
using LivrariaPlus.Api.Communication.Requests;
using LivrariaPlus.Api.Data.Repositories;
using LivrariaPlus.Api.Extensions;

namespace LivrariaPlus.Api.UseCases.Books.Create
{
    public class CreateBookUseCase
    {
        private readonly BookRepository _bookRepository;
        private readonly UnitOfWork _unitOfWork;

        public CreateBookUseCase(BookRepository bookRepository, UnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(CreateBookRequestJson request)
        {
            Validate(request);

            var bookExists = await _bookRepository.ExistsByTitleAndAuthorAsync(request.Title, request.Author);
            if (bookExists)
            {
                throw new ErrorOnValidationException(["Book already exists."]);
            }

            var book = request.ToEntity();
            await _bookRepository.CreateAsync(book);
            await _unitOfWork.CommitAsync();
        }

        private void Validate(CreateBookRequestJson request)
        {
            var result = new CreateBookUseCaseValidator().Validate(request);

            if (result.IsValid.IsFalse())
            {
                throw new ErrorOnValidationException(result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }
    }
}