using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> _repository;

        public DeleteUserHandler(IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
