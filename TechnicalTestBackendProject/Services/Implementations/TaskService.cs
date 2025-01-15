using MediatR;
using TechnicalTestBackendProject.CQRS.Commands;
using TechnicalTestBackendProject.CQRS.Queries;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IMediator _mediator;
        public TaskService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TaskReadDTO> CreateTaskAsync(TaskCreateDTO entity)
        {
            var task = await _mediator.Send(new CreateTaskCommand(entity));
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int id, int userId)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            if (task == null || task.CreatedById != userId) return false;

            var result = await _mediator.Send(new DeleteTaskCommand(id));
            return result;
        }

        public async Task<IEnumerable<TaskReadDTO>> GetAllTasksAsync()
        {
            return await _mediator.Send(new GetAllTasksQuery());
        }

        public async Task<IEnumerable<string>> GetAllTasksStatus()
        {
            return Enum.GetNames(typeof(TaskStatusEnum));
        }

        public async Task<IEnumerable<TaskReadDTO>> GetTasksByBoardId(int userId, int boardId)
        {
            var board = await _mediator.Send(new GetBoardByIdQuery(userId));
            if (board == null || board.CreatedById != userId) return null;

            return await _mediator.Send(new GetTasksByBoardIdQuery(userId));
        }

        public async Task<TaskReadDTO> GetTaskByIdAsync(int id, int userId)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(id));
            if (task == null || task.CreatedById != userId) return null;

            return task;
        }

        public async Task<TaskReadDTO> UpdateTaskAsync(TaskUpdateDTO entity, int userId)
        {
            var task = await _mediator.Send(new GetTaskByIdQuery(entity.Id));
            if (task == null || task.CreatedById != userId) return null;

            var taskUpdated = await _mediator.Send(new UpdateTaskCommand(entity));

            return taskUpdated;
        }
    }
}
