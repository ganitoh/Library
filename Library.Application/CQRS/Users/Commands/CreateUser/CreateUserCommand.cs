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
        public int RoleId { get; set; }

        public CreateUserCommand()
        {
            Id = Guid.NewGuid();
        }

        public CreateUserCommand(string login)
        {
            Id = Guid.NewGuid();
            Login = login;
        }

        public CreateUserCommand(string login, int roleId) 
            : this(login)
        {
            Id = Guid.NewGuid();
            RoleId = roleId;
        }

        public CreateUserCommand(string login, string passwordHash, int roleId) 
            : this(login)
        {
            Id = Guid.NewGuid();
            PasswordHash = passwordHash;
            RoleId = roleId;
        }
    }
}
