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
        private readonly IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO> _repository;

        public UpdateBoardHandler(IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO> repository)
        {
            _repository = repository;
        }

        public async Task<BoardReadDTO> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.boardData);
        }
    }
}
