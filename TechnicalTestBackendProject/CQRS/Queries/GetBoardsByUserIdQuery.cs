using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetBoardsByUserIdQuery(int userId) : IRequest<IEnumerable<BoardReadDTO>>;
}
