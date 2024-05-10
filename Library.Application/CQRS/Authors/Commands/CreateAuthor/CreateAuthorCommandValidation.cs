using FluentValidation;

namespace Library.Application.CQRS.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidation 
        : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidation()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Description).MaximumLength(1024);
        }
    }
}
