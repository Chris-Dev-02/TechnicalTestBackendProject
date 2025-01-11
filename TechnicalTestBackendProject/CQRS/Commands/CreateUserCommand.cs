using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record CreateUserCommand(string Username, string Email, string Paswword, Role UserRole) : IRequest<UserCreateDTO>;
}
