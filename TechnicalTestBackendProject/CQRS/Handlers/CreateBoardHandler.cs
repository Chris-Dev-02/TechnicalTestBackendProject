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
    public class CreateBoardHandler : IRequestHandler<CreateBoardCommand, BoardReadDTO>
    {
        private readonly IBoardRepository _repository;

        public CreateBoardHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<BoardReadDTO> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddBoardAsync(request.boardData);
        }
    }
}
