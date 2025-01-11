using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public Task<TaskReadDTO> Create(TaskCreateDTO taskCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<TaskReadDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskReadDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TaskReadDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskReadDTO> Update(TaskUpdateDTO taskUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
