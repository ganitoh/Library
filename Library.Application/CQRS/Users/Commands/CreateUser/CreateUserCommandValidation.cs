using FluentValidation;

namespace Library.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandValidation 
        : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(u=>u.Id).NotEmpty();
            RuleFor(u => u.RoleId).NotEmpty();
            RuleFor(u=>u.Login).NotEmpty().MaximumLength(120);
            RuleFor(u=>u.PasswordHash).NotEmpty();
        }
    }
}
