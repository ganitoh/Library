using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.Services.Repositories.Abstraction;
using MediatR;

namespace Library.Application.CQRS.Books.Commands.CreateBook
{
    public class CreateBookCommandHanlder
        : IRequestHandler<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHanlder(
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookRepository.CreateEntityAsync(book);
        }
    }
}
