using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserReadDTO>
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserReadDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateUserAsync(request.userData);
        }
    }
}
