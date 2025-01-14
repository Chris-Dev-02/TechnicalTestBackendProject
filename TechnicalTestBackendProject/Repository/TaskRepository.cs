using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;
        private readonly IMapper _mapper;

        public TaskRepository(ApplicationDbContext context, IConnectionMultiplexer redis, IMapper mapper)
        {
            _dbContext = context;
            _redis = redis;
            _cache = redis.GetDatabase();
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskReadDTO>> GetAllTasksAsync()
        {
            // Check if the data is in the cache
            var cachedTasks = await _cache.StringGetAsync("Tasks");
            if (cachedTasks.HasValue)
            {
                return JsonSerializer.Deserialize<IEnumerable<TaskReadDTO>>(cachedTasks);
            }

            // If the data is not in the cache
            var tasks = await _dbContext.Tasks.ToListAsync();

            await _cache.StringSetAsync("Tasks", JsonSerializer.Serialize(tasks));

            return tasks.Select(task => _mapper.Map<TaskReadDTO>(task));
        }

        public async Task<TaskReadDTO> GetTaskByIdAsync(int id)
        {
            // Check if the data is in the cache
            var cachedTask = _cache.StringGet($"Task:{id}");
            if (cachedTask.HasValue)
            {
                return JsonSerializer.Deserialize<TaskReadDTO>(cachedTask);
            }

            // If the data is not in the cache, get it from the database
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                _cache.StringSet($"Task:{task.Id}", JsonSerializer.Serialize(task));
            }

            var TaskReadDTO = _mapper.Map<TaskReadDTO>(task);

            return TaskReadDTO;
        }

        public async Task<TaskReadDTO> AddTaskAsync(TaskCreateDTO entity)
        {
            var newTask = _mapper.Map<TaskModel>(entity);

            await _dbContext.Tasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();

            // Updating Redis Cache
            _cache.StringSet($"Task:{newTask.Id}", JsonSerializer.Serialize(newTask));

            var TaskReadDTO = _mapper.Map<TaskReadDTO>(newTask);

            return TaskReadDTO;
        }

        public async Task<TaskReadDTO> UpdateTaskAsync(TaskUpdateDTO entity)
        {
            var taskToUpdate = await _dbContext.Tasks.FindAsync(entity.Id);

            if (taskToUpdate == null)
            {
                return null;
            }

            taskToUpdate.Title = entity.Title;
            taskToUpdate.Description = entity.Description;
            taskToUpdate.TaskStatus = entity.TaskStatus;

            taskToUpdate = _mapper.Map<TaskUpdateDTO, TaskModel>(entity, taskToUpdate);

            await _dbContext.SaveChangesAsync();

            // Updating Redis Cache
            _cache.StringSet($"Task:{taskToUpdate.Id}", JsonSerializer.Serialize(taskToUpdate));

            var TaskReadDTO = _mapper.Map<TaskReadDTO>(taskToUpdate);

            return TaskReadDTO;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var taskToDelete = await _dbContext.Tasks.FindAsync(id);

            if (taskToDelete == null)
            {
                return false;
            }

            _dbContext.Tasks.Remove(taskToDelete);
            await _dbContext.SaveChangesAsync();

            // Deleting from Redis Cache
            _cache.KeyDelete($"Task:{id}");

            return true;
        }

        public async Task<IEnumerable<TaskReadDTO>> GetTasksByBoardIdAndUserIdAsync(int boarId)
        {
            var tasks = await _dbContext.Tasks.Where(t => t.BoardId == boarId.ToString() ).ToListAsync();

            return tasks.Select(task => _mapper.Map<TaskReadDTO>(task));
        }
    }
}
