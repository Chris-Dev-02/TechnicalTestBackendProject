using Microsoft.AspNetCore.Http.HttpResults;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Repository
{
    public interface IBoardRepository
    {
        Task<IEnumerable<BoardReadDTO>> GetAllBoardsAsync();
        Task<IEnumerable<BoardReadDTO>> GetBoardsByUserIdAsync(int userId);
        Task<BoardReadDTO> GetBoardByIdAsync(int id);
        Task<BoardReadDTO> AddBoardAsync(BoardCreateDTO entity);
        Task<BoardReadDTO> UpdateBoardAsync(BoardUpdateDTO entity);
        Task<bool> DeleteBoardAsync(int id);
        Task<IEnumerable<BoardStatisticsDTO>> GetStatisticsAsync(int userId);
    }
}
