using MediatR;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record DeleteUserCommand(int Id) : IRequest<bool>;
}
