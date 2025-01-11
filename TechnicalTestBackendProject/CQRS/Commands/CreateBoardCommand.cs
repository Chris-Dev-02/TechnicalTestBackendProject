using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record CreateBoardCommand(string Name, string Description, string CreatesBy) : IRequest<BoardCreateDTO>;
}
