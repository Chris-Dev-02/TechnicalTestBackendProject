using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IValidator<TaskCreateDTO> _createTaskValidator;
        private readonly IValidator<TaskUpdateDTO> _updateTaskValidator;
        public TaskController(IValidator<TaskCreateDTO> createTaskValidator, IValidator<TaskUpdateDTO> updateTaskValidator) 
        {
            _createTaskValidator = createTaskValidator;
            _updateTaskValidator = updateTaskValidator;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTaskById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskCreateDTO TaskData)
        {
            var validationResult = _createTaskValidator.Validate(TaskData);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTask([FromBody] TaskUpdateDTO TaskData)
        {
            var validationResult = _updateTaskValidator.Validate(TaskData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTask(int id)
        {
            return Ok();
        }
    }
}
