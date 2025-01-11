using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetBoardByIdQuery(int Id) : IRequest<BoardReadDTO>;
}
