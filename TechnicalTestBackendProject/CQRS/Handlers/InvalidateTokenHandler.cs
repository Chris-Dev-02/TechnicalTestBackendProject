using MediatR;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class InvalidateTokenHandler : IRequestHandler<InvalidateTokenCommand, bool>
    {
        private readonly ITokenRepository _repository;

        public InvalidateTokenHandler(ITokenRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(InvalidateTokenCommand request, CancellationToken cancellationToken)
        {
            return await _repository.InvalidateTokenAsync(request.token);
        }
    }
}
