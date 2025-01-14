using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface ITaskSpecificActions
    {
        Task<IEnumerable<TaskReadDTO>> GetAllTaskByUserAndBoard(int userId, int boardId);
        Task<IEnumerable<string>> GetAllTasksStatus();
    }
}
