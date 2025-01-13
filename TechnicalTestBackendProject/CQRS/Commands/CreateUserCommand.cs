using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record CreateUserCommand(UserCreateDTO userData) : IRequest<UserReadDTO>;
}
