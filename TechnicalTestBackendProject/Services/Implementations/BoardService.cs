using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class BoardService : ICRUDActionsService<BoardReadDTO, BoardCreateDTO, BoardUpdateDTO>
    {
        public Task<IEnumerable<BoardReadDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BoardReadDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<BoardReadDTO> Create(BoardCreateDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<BoardReadDTO> Update(BoardUpdateDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<BoardReadDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
