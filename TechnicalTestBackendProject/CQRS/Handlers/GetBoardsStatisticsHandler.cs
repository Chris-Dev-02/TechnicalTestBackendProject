using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetBoardsStatisticsHandler : IRequestHandler<GetBoardsStatisticsQuery, IEnumerable<BoardStatisticsDTO>>
    {
        private readonly IBoardRepository _repository;

        public GetBoardsStatisticsHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BoardStatisticsDTO>> Handle(GetBoardsStatisticsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStatisticsAsync(request.userId);
        }
    }
}
