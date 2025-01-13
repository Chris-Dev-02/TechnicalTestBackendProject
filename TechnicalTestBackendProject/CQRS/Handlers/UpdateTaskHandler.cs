using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskReadDTO>
    {
        private readonly IRepository<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO> _repository;

        public UpdateTaskHandler(IRepository<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO> repository)
        {
            _repository = repository;
        }

        public async Task<TaskReadDTO> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.taskData);
        }
    }
}
