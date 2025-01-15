using MediatR;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class IsValidTokenHandler : IRequestHandler<IsValidTokenQuery, bool>
    {
        private readonly ITokenRepository _repository;

        public IsValidTokenHandler(ITokenRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(IsValidTokenQuery request, CancellationToken cancellationToken)
        {
            return await _repository.IsTokenValidAsync(request.token);
        }
    }
}
