using Library.Domain.Models;
using MediatR;

namespace Library.Application.CQRS.Users.Queries.GetUserByLogin
{
    public class GetUserByLoginRequest : IRequest<User>
    {
        public string Login { get; set; } = string.Empty;
        public GetUserByLoginRequest() { }

        public GetUserByLoginRequest(string login)
        {
            Login = login;
        }
    }
}
