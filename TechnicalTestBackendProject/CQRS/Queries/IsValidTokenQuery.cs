using MediatR;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.CQRS.Queries
{
    public record IsValidTokenQuery(string token) : IRequest<bool>;
}
