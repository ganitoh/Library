using Library.Application.Common.Services.Abstraction;
using Library.Application.CQRS.Users.Commands.CreateUser;
using Library.Application.CQRS.Users.Queries.GetUserByLogin;
using MediatR;

namespace Library.Application.Common.Services.Emplemantation
{
    public class AccountService : IAccountService
    {
        private readonly IMediator _mediator;

        public AccountService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Login(GetUserByLoginRequest request, string password)
        {
            throw new NotImplementedException();
        }

        public Task RegistrationAccount(string password, CreateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
