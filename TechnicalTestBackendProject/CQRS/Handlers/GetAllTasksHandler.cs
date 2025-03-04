﻿using MediatR;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Repository;

namespace TechnicalTestBackendProject.CQRS.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskReadDTO>>
    {
        private readonly ITaskRepository _repository;

        public GetAllTasksHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskReadDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllTasksAsync();
        }
    }
}
