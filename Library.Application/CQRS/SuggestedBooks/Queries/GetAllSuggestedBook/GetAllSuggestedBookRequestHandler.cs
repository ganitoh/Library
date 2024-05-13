using Library.Domain.Models;
using MediatR;

namespace Library.Application.CQRS.SuggestedBooks.Queries.GetAllSuggestedBook
{
    public class GetAllSuggestedBookRequestHandler 
        : IRequestHandler<GetAllSuggestedBookRequest,IEnumerable<SuggestedBook>>
    {
        private
    }
}
