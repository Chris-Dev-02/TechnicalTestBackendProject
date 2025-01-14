using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class BoardService : IBoardService
    {
        private readonly IMediator _mediator;
        public BoardService(IMediator mediator) 
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<BoardReadDTO>> GetAllBoardsAsync()
        {
            return await _mediator.Send(new GetAllBoardsQuery());
        }

        public Task<IEnumerator<BoardReadDTO>> GetAllBoardsByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BoardReadDTO> GetBoardByIdAsync(int id, int userId)
        {
            var board = await _mediator.Send(new GetBoardByIdQuery(id));
            if(board == null || board.CreatedById != userId.ToString()) return null;

            return board;
        }

        public Task GetStatisticsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BoardReadDTO> CreateBoardAsync(BoardCreateDTO entity)
        {
            var board = await _mediator.Send(new CreateBoardCommand(entity));

            return board;
        }
        public async Task<BoardReadDTO> UpdateBoardAsync(BoardUpdateDTO entity, int userId)
        {
            var board = await _mediator.Send(new GetBoardByIdQuery(entity.Id));
            if (board == null || board.CreatedById != userId.ToString()) return null;

            var boardUpdated = await _mediator.Send(new UpdateBoardCommand(entity));

            return boardUpdated;
        }

        public async Task<bool> DeleteBoardAsync(int id, int userId)
        {
            var board = await _mediator.Send(new GetBoardByIdQuery(id));
            if (board == null || board.CreatedById != userId.ToString()) return false;

            var result = await _mediator.Send(new DeleteBoardCommand(id));
            return result;
        }
    }
}
