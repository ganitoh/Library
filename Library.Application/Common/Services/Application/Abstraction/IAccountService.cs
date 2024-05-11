using Library.Application.CQRS.Users.Commands.CreateUser;
using Library.Application.CQRS.Users.Queries.GetUserByLogin;
using Library.Domain.Models;

namespace Library.Application.Common.Services.Application.Abstraction
{
    public interface IAccountService
    {
        Task RegistrationAccount(CreateUserCommand command, string password);
        Task<User> Login(GetUserByLoginRequest request, string password);
    }
}
