using FluentValidation;

namespace Library.Application.CQRS.SuggestedBooks.Command.CreateSuggestedBook
{
    public class CreateSuggestedBookComamndValidation 
        : AbstractValidator<CreateSuggestedBookComamnd>
    {
        public CreateSuggestedBookComamndValidation()
        {
            RuleFor(b => b.NameBook).MaximumLength(512).NotEmpty();
            RuleFor(b=>b.AuthoData).NotEmpty();
            RuleFor(b=>b.SuggetsByUser).NotEmpty();
            RuleFor(b=>b.SuggestByUserid).GreaterThan(0);
        }
    }
}
