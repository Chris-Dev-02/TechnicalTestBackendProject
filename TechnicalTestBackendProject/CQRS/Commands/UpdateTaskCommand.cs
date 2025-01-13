using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record UpdateTaskCommand(TaskUpdateDTO taskData) : IRequest<TaskReadDTO>;
}
