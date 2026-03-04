using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LivrariaPlus.Api.Communication.Requests;

namespace LivrariaPlus.Api.UseCases.Books.Update
{
    public class UpdateBookUseCaseValidator : AbstractValidator<UpdateBookRequestJson>
    {
        public UpdateBookUseCaseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("You must provide a title for the book")
                .Length(2, 120).WithMessage("The title must have between 2 and 120 characters")
                .When(x => x.Title != null);

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author name is required if provided")
                .When(x => x.Author != null);

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0")
                .When(x => x.Price != null);

            RuleFor(x => x.Genre)
                .IsInEnum().WithMessage("Invalid genre")
                .When(x => x.Genre != null);

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to 0")
                .When(x => x.Stock != null);
        }
    }
}