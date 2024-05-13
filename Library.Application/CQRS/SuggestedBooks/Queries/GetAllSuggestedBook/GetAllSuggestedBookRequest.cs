using Library.Domain.Models;
using MediatR;

namespace Library.Application.CQRS.SuggestedBooks.Queries.GetAllSuggestedBook
{
    public class GetAllSuggestedBookRequest 
        : IRequest<IEnumerable<SuggestedBook>> { }
}
