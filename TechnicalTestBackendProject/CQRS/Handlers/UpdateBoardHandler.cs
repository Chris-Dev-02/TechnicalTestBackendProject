using MediatR;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class UpdateBoardHandler : IRequestHandler<UpdateBoardCommand, BoardReadDTO>
    {
        private readonly IBoardRepository _repository;

        public UpdateBoardHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<BoardReadDTO> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateBoardAsync(request.boardData);
        }
    }
}
