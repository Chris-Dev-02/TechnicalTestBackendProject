using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<TaskState>> GetAllStates();
        Task<IEnumerable<BoardReadDTO>> Get();
        Task<BoardReadDTO> GetById(int id);
        Task<BoardReadDTO> Create(BoardCreateDTO  boardCreateDto);
        Task<BoardReadDTO> Update(BoardUpdateDTO boardUpdateDto);
        Task<BoardReadDTO> Delete(int id);
    }
}
