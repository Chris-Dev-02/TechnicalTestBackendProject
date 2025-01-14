using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetTasksByBoardIdQuery(int boardId) : IRequest<IEnumerable<TaskReadDTO>>;
}
