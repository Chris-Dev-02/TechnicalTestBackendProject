using MediatR;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
