using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsQuery, IEnumerable<BoardReadDTO>>
    {
        private readonly IBoardRepository _repository;

        public GetAllBoardsHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BoardReadDTO>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllBoardsAsync();
        }
    }
}
