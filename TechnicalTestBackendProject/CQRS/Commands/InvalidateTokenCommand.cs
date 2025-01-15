using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record InvalidateTokenCommand(string token) : IRequest<bool>;
}
