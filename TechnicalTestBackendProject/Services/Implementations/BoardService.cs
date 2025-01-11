using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class BoardService : IBoardService
    {
        public Task<BoardReadDTO> Create(BoardCreateDTO boardCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<BoardReadDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BoardReadDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BoardReadDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BoardReadDTO> Update(BoardUpdateDTO boardUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
