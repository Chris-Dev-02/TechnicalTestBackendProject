using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetAllUsersQuery : IRequest<IEnumerable<UserReadDTO>>;
}
