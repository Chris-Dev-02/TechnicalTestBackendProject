using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsQuery, IEnumerable<BoardReadDTO>>
    {
        private readonly IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO> _repository;

        public GetAllBoardsHandler(IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BoardReadDTO>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
