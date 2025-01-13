using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserReadDTO>
    {
        private readonly IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> _repository;

        public CreateUserHandler(IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> repository)
        {
            _repository = repository;
        }
        public async Task<UserReadDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.userData);
        }
    }
}
