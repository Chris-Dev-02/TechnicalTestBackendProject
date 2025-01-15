using Microsoft.AspNetCore.Http.HttpResults;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDTO>> GetAllTasksAsync();
        Task<TaskReadDTO> GetTaskByIdAsync(int id, int userId);
        Task<TaskReadDTO> CreateTaskAsync(TaskCreateDTO entity);
        Task<TaskReadDTO> UpdateTaskAsync(TaskUpdateDTO entity, int userId);
        Task<bool> DeleteTaskAsync(int id, int userId);
        Task<IEnumerable<TaskReadDTO>> GetTasksByBoardId(int boardId, int userId);
        Task<IEnumerable<string>> GetAllTasksStatus();
    }
}
