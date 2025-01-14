using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetBoardsByUserIdHandler : IRequestHandler<GetBoardsByUserIdQuery, IEnumerable<BoardReadDTO>>
    {
        private readonly IBoardRepository _repository;

        public GetBoardsByUserIdHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BoardReadDTO>> Handle(GetBoardsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBoardsByUserIdAsync(request.userId);
        }
    }
}
