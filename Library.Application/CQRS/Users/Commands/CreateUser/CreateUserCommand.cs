using Library.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid RoleId { get; set; }

        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public CreateUserCommand(string login, string passwordHash, Guid roleId)
        {
            Id = Guid.NewGuid();
            Login = login;
            PasswordHash = passwordHash;
            RoleId = roleId;
        }
    }
}
