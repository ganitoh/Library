using Library.Domain.Models;
using MediatR;


namespace Library.Application.CQRS.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest
    {
        public Guid Id { get; set; }
        public FIO Name { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public string Description { get; set; } = string.Empty;

        public CreateAuthorCommand()=> Id = Guid.NewGuid();

        public CreateAuthorCommand(FIO name, DateTime dateBirth, string description)
        {
            Id= Guid.NewGuid();
            Name = name;
            DateBirth = dateBirth;
            Description = description;
        }
    }
}
