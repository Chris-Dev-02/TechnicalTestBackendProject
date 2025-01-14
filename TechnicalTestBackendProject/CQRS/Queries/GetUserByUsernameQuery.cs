using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record GetUserByUsernameQuery(string username) : IRequest<UserDTO>;
}
