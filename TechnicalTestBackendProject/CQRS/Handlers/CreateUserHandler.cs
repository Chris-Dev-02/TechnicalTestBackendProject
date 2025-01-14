using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserReadDTO>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserReadDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddUserAsync(request.userData);
        }
    }
}
