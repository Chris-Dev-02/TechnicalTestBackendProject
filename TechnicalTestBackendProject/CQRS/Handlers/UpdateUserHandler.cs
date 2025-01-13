using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserReadDTO>
    {
        private readonly IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> _repository;

        public UpdateUserHandler(IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> repository)
        {
            _repository = repository;
        }
        public async Task<UserReadDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.userData);
        }
    }
}
