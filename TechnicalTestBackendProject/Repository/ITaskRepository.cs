using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskReadDTO>> GetAllTasksAsync();
        Task<IEnumerable<TaskReadDTO>> GetTasksByBoardIdAsync(int boardId);
        Task<TaskReadDTO> GetTaskByIdAsync(int id);
        Task<TaskReadDTO> AddTaskAsync(TaskCreateDTO entity);
        Task<TaskReadDTO> UpdateTaskAsync(TaskUpdateDTO entity);
        Task<bool> DeleteTaskAsync(int id);
    }
}
