using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record UpdateBoardCommand(int Id, string Name, string Description) : IRequest<BoardUpdateDTO>;
}
