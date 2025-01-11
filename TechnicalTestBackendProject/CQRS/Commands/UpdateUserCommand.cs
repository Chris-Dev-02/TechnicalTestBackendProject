using MediatR;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.CQRS.Commands
{
    public record UpdateUserCommand(int Id, string Username, string Email, string Paswword, Role UserRole) : IRequest<UserUpdateDTO>;
}
