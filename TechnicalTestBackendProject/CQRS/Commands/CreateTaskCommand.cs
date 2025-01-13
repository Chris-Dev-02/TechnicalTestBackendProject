using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record CreateTaskCommand(TaskCreateDTO taskData) : IRequest<TaskReadDTO>;
}
