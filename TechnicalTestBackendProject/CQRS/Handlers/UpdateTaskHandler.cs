using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskReadDTO>
    {
        private readonly ITaskRepository _repository;

        public UpdateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskReadDTO> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateTaskAsync(request.taskData);
        }
    }
}
