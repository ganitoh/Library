using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.Services.Repositories.Abstraction;
using MediatR;

namespace Library.Application.CQRS.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request);
            await _authorRepository.CreateEntityAsync(author);
        }
    }
}
