using Library.Domain.Models;
using Library.Persistance.Services.Repositories.Abstraction;
using MediatR;

namespace Library.Application.CQRS.SuggestedBooks.Queries.GetAllSuggestedBook
{
    public class GetAllSuggestedBookRequestHandler 
        : IRequestHandler<GetAllSuggestedBookRequest, IEnumerable<SuggestedBook>>
    {
        private readonly ISuggestedBookRepository _suggestBookRepository;

        public GetAllSuggestedBookRequestHandler(ISuggestedBookRepository suggestBookRepository)
        {
            _suggestBookRepository = suggestBookRepository;
        }

        public async Task<IEnumerable<SuggestedBook>> Handle(
            GetAllSuggestedBookRequest request,
            CancellationToken cancellationToken)
        {
            return await _suggestBookRepository.GetAllEntitiesAsync();
        }
    }
}
