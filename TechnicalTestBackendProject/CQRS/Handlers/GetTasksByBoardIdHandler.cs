using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetTasksByBoardIdHandler : IRequestHandler<GetTasksByBoardIdQuery, IEnumerable<TaskReadDTO>>
    {
        private readonly ITaskRepository _repository;

        public GetTasksByBoardIdHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskReadDTO>> Handle(GetTasksByBoardIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTasksByBoardIdAndUserIdAsync(request.boardId);
        }
    }
}
