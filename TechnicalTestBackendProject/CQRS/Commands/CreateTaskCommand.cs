using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record CreateTaskCommand(int Id, string Title, string Description, string BoardId, TaskState TaskState) : IRequest<TaskCreateDTO>;
}
