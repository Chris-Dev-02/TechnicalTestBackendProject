using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        public BoardController() { }

        [HttpGet]
        public IActionResult GetAllBoards()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBoardById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateBoard()
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBoard(int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBoard(int id)
        {
            return Ok();
        }
    }
}
