using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record UpdateTaskCommand(int Id, string Title, string Description, TaskState TaskState) : IRequest<TaskUpdateDTO>;
}
