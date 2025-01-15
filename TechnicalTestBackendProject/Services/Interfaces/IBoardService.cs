using Microsoft.AspNetCore.Http.HttpResults;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardReadDTO>> GetAllBoardsAsync();
        Task<BoardReadDTO> GetBoardByIdAsync(int id, int userId);
        Task<BoardReadDTO> CreateBoardAsync(BoardCreateDTO entity);
        Task<BoardReadDTO> UpdateBoardAsync(BoardUpdateDTO entity, int userId);
        Task<bool> DeleteBoardAsync(int id, int userId);
        Task<IEnumerable<BoardReadDTO>> GetAllBoardsByUserAsync(int userId);
        Task<IEnumerable<BoardStatisticsDTO>> GetStatisticsAsync(int userId);
    }
}
