using MediatR;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetBoardByIdHandler : IRequestHandler<GetBoardByIdQuery, BoardReadDTO>
    {
        private readonly IBoardRepository _repository;

        public GetBoardByIdHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<BoardReadDTO> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBoardByIdAsync(request.Id);
        }
    }
}
