using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IValidator<TaskCreateDTO> _createTaskValidator;
        private readonly IValidator<TaskUpdateDTO> _updateTaskValidator;
        private readonly ITaskService _taskService;
        public TaskController(
            IValidator<TaskCreateDTO> createTaskValidator, 
            IValidator<TaskUpdateDTO> updateTaskValidator,
            ITaskService taskService) 
        {
            _createTaskValidator = createTaskValidator;
            _updateTaskValidator = updateTaskValidator;
            _taskService = taskService;
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}/board/{boarId}")]
        public async Task<IActionResult> GetAllTasksByBoardId(int id, int boardId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (currentUserId == null || int.Parse(currentUserId) != userId) return Unauthorized();
            if(currentUserId != null) return Unauthorized();

            var tasks = await _taskService.GetTasksByBoardId(id, boardId);
            return Ok(tasks);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();

            var task = await _taskService.GetTaskByIdAsync(id, int.Parse(userId));
            if (task == null) NotFound();

            return Ok(task);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDTO TaskData)
        {
            var validationResult = _createTaskValidator.Validate(TaskData);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();
            //TaskData.CreatedById = userId;

            var task = await _taskService.CreateTaskAsync(TaskData);

            return Ok(task);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateDTO TaskData)
        {
            var validationResult = _updateTaskValidator.Validate(TaskData);

            if(!validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();

            var task = await _taskService.UpdateTaskAsync(TaskData, int.Parse(userId));
            if (task == null) NotFound();

            return Ok(task);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var result = await _taskService.DeleteTaskAsync(id, int.Parse(userId));
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
