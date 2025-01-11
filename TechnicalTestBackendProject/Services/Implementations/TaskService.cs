using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class TaskService : ICRUDService<TaskModel>
    {
        public Task<TaskModel> Create(TaskModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskModel>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel> Update(int id, TaskModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
