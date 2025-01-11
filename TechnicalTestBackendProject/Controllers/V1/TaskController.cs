using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController() { }

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
        public IActionResult CreateTask()
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTask(int id)
        {
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
