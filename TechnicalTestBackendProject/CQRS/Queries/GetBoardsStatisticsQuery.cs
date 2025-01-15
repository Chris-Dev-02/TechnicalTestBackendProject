using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetBoardsStatisticsQuery(int userId) : IRequest<IEnumerable<BoardStatisticsDTO>>;
}
