using Microsoft.AspNetCore.Http.HttpResults;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDTO>> Get();
        Task<TaskReadDTO> GetById(int id, int userId);
        Task<TaskReadDTO> Create(TaskCreateDTO entity);
        Task<TaskReadDTO> Update(TaskUpdateDTO entity, int userId);
        Task<bool> Delete(int id, int userId);
        Task<IEnumerable<TaskReadDTO>> GetAllTaskByUserAndBoard(int userId, int boardId);
        Task<IEnumerable<string>> GetAllTasksStatus();
    }
}
