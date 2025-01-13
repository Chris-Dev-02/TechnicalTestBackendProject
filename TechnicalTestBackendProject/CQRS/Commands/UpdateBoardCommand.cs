using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record UpdateBoardCommand(BoardUpdateDTO boardData) : IRequest<BoardReadDTO>;
}
