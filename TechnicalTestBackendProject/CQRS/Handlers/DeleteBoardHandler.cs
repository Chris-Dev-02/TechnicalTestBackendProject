using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class DeleteBoardHandler : IRequestHandler<DeleteBoardCommand, bool>
    {
        private readonly IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO> _repository;

        public DeleteBoardHandler(IRepository<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
        { 
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
