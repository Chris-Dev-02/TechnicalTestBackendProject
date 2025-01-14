using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskReadDTO>
    {
        private readonly ITaskRepository _repository;

        public GetTaskByIdHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskReadDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTaskByIdAsync(request.Id);
        }
    }
}
