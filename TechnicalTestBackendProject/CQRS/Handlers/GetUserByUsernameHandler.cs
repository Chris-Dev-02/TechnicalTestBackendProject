using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, UserDTO>
    {
        private readonly IUserRepository _repository;

        public GetUserByUsernameHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDTO> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserByUsernameAsync(request.username);
        }
    }
}
