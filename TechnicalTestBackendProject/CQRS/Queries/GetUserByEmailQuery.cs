using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetUserByEmailQuery(string email) : IRequest<UserDTO>;
}
