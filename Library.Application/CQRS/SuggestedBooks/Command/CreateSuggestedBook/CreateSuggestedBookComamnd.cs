using Library.Domain.Models;
using MediatR;

namespace Library.Application.CQRS.SuggestedBooks.Command.CreateSuggestedBook
{
    public class CreateSuggestedBookComamnd : IRequest
    {
        public Guid Id { get; set; }
        public string NameBook { get; set; } = string.Empty;
        public FIO? AuthoData { get; set; }
        public Guid SuggestByUserid { get; set; }
        public User SuggetsByUser { get; set; } = null!;

        public CreateSuggestedBookComamnd()
        {
            Id = Guid.NewGuid();
        }

        public CreateSuggestedBookComamnd(string nameBook, FIO? authoData, Guid suggestByUserid, User suggetsByUser)
        {
            Id = Guid.NewGuid();
            NameBook = nameBook;
            AuthoData = authoData;
            SuggestByUserid = suggestByUserid;
            SuggetsByUser = suggetsByUser;
        }
    }
}
