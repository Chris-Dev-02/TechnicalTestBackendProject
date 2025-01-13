using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly IRepository<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO> _repository;

        public DeleteTaskHandler(IRepository<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
