using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<UserReadDTO>;
}
