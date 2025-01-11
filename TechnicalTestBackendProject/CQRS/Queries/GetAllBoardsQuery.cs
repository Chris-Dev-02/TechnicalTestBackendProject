using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetAllBoardsQuery : IRequest<IEnumerable<BoardReadDTO>>;
}
