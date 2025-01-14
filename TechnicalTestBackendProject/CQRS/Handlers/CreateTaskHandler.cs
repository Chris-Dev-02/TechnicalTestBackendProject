using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskReadDTO>
    {
        private readonly ITaskRepository _repository;

        public CreateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskReadDTO> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddTaskAsync(request.taskData);
        }
    }
}
