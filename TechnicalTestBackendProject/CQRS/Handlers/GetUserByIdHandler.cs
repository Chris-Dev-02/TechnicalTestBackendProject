using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserReadDTO>
    {
        private readonly IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> _repository;

        public GetUserByIdHandler(IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> repository)
        {
            _repository = repository;
        }

        public async Task<UserReadDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
