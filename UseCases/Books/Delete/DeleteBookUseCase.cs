using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Exceptions;
using LivrariaPlus.Api.Data.Repositories;

namespace LivrariaPlus.Api.UseCases.Books.Delete
{
    public class DeleteBookUseCase
    {
        private readonly BookRepository _bookRepository;
        private readonly UnitOfWork _unitOfWork;

        public DeleteBookUseCase(BookRepository bookRepository, UnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(Guid bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book is null)
            {
                throw new ErrorOnValidationException(["Book not found."]);
            }

            await _bookRepository.DeleteAsync(book);
            await _unitOfWork.CommitAsync();
        }
    }
}