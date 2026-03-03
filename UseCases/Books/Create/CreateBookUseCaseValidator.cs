using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LivrariaPlus.Api.Communication.Requests;

namespace LivrariaPlus.Api.UseCases.Books.Create
{
    public class CreateBookUseCaseValidator : AbstractValidator<CreateBookRequestJson>
    {
        public CreateBookUseCaseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("The book title is required.")
                .Length(2, 120)
                .WithMessage("The book title must be between 2 and 120 characters.");

            RuleFor(x => x.Author)
                .NotEmpty()
                .WithMessage("The book author is required.")
                .Length(2, 120)
                .WithMessage("The book author must be between 2 and 120 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The book price must be greater than zero.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The book stock must be greater than or equal to zero.");

            RuleFor(x => x.Genre)
                .IsInEnum()
                .WithMessage("The book genre is invalid.");
        }
    }
}