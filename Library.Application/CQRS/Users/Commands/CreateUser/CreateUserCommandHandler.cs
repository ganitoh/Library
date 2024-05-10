using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.Services.Repositories.Abstraction;
using MediatR;

namespace Library.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.CreateEntityAsync(user);
        }
    }
}
