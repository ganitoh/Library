using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.Services.Repositories.Abstraction;
using MediatR;


namespace Library.Application.CQRS.SuggestedBooks.Command.CreateSuggestedBook
{
    public class CreateSuggestedBookComamndHandler 
        : IRequestHandler<CreateSuggestedBookComamnd>
    {

        private readonly ISuggestedBookRepository _suggestedBookRepository;
        private readonly IMapper _mapper;

        public CreateSuggestedBookComamndHandler(
            ISuggestedBookRepository repository,
            IMapper mapper)
        {
            _suggestedBookRepository = repository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateSuggestedBookComamnd request,
            CancellationToken cancellationToken)
        {
            var suggestedBook = _mapper.Map<SuggestedBook>(request);
            await _suggestedBookRepository.CreateEntityAsync(suggestedBook);
        }
    }
}
