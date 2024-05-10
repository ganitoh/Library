using FluentValidation;

namespace Library.Application.CQRS.Books.Commands.CreateBook
{
    public class CreateBookCommandValidation 
        : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidation()
        {
            RuleFor(b=>b.Name).NotEmpty();
            RuleFor(b => b.AuthorId).NotEmpty();
            RuleFor(b=>b.Description).MaximumLength(1024);
            RuleFor(b=>b.CountPage).GreaterThan(0);
        }
    }
}
