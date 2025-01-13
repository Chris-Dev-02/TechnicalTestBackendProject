using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserReadDTO>>
    {
        private readonly IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> _repository;

        public GetAllUsersHandler(IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<UserReadDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
