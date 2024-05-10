using MediatR;

namespace Library.Application.CQRS.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CountPage { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime DateWriting { get; set; }

        public CreateBookCommand()
        {
            Id = Guid.NewGuid();
        }

        public CreateBookCommand(string name, string description, int countPage, Guid authorId, DateTime dateWriting)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            CountPage = countPage;
            AuthorId = authorId;
            DateWriting = dateWriting;
        }
    }
}
