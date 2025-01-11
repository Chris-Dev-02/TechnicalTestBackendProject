using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetAllTasksQuery : IRequest<IEnumerable<TaskReadDTO>>;
}
