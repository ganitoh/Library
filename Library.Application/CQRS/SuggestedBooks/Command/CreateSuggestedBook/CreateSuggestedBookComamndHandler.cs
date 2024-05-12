using AutoMapper;
using Library.Persistance.Services.Repositories.Abstraction;
using MediatR;


namespace Library.Application.CQRS.SuggestedBooks.Command.CreateSuggestedBook
{
    public class CreateSuggestedBookComamndHandler 
        : IRequestHandler<CreateSuggestedBookComamnd>
    {

        private readonly ISuggestedBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateSuggestedBookComamndHandler(
            ISuggestedBookRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(CreateSuggestedBookComamnd request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
