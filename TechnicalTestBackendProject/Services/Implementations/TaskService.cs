﻿using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class TaskService : ICRUDActionsService<TaskReadDTO, TaskCreateDTO, TaskUpdateDTO>
    {
        public Task<IEnumerable<TaskReadDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TaskReadDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<TaskReadDTO> Create(TaskCreateDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<TaskReadDTO> Update(TaskUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<TaskReadDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
