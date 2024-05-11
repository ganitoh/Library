using Library.Application.Common.Exceptions;
using Library.Application.Common.Services.Application.Abstraction;
using Library.Application.Common.Services.HasherProvider;
using Library.Application.CQRS.Users.Commands.CreateUser;
using Library.Application.CQRS.Users.Queries.GetUserByLogin;
using Library.Domain.Models;
using MediatR;

namespace Library.Application.Common.Services.Application.Emplementation
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordHash _passwordHash;
        private readonly IMediator _mediator;

        public AccountService(IPasswordHash passwordHash, IMediator mediator)
        {
            _passwordHash = passwordHash;
            _mediator = mediator;
        }

        public async Task<User> Login(GetUserByLoginRequest request, string password)
        {
            var user = await _mediator.Send(request);

            if (_passwordHash.VerifyPassword(password, user.PasswordHash))
                throw new PasswordUncorrectException("пароль не подходит",request.Login);

            return user;
        }

        public async Task RegistrationAccount(CreateUserCommand command, string password)
        {
            command.PasswordHash = _passwordHash.PasswordHash(password);
            await _mediator.Send(command);
        }
    }
}
