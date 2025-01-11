using MediatR;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record DeleteBoardCommand(int Id) : IRequest<bool>;
}
