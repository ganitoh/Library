using Library.Application.CQRS.Users.Commands.CreateUser;
using Library.Application.CQRS.Users.Queries.GetUserByLogin;

namespace Library.Application.Common.Services.Abstraction
{
    public interface IAccountService
    {
        Task RegistrationAccount(string password,CreateUserCommand command);
        Task Login(GetUserByLoginRequest request, string password);
    }
}
