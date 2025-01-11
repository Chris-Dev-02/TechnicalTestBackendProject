using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDTO>> Get();
        Task<TaskReadDTO> GetById(int id);
        Task<TaskReadDTO> Create(TaskCreateDTO  taskCreateDto);
        Task<TaskReadDTO> Update(TaskUpdateDTO taskUpdateDto);
        Task<TaskReadDTO> Delete(int id);
    }
}
