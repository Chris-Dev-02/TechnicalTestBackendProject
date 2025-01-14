using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IValidator<BoardCreateDTO> _createBoardValidator;
        private readonly IValidator<BoardUpdateDTO> _updateBoardValidator;
        public BoardController(IValidator<BoardCreateDTO> createBoardValidator, IValidator<BoardUpdateDTO> updateBoardValidator) 
        {
            _createBoardValidator = createBoardValidator;
            _updateBoardValidator = updateBoardValidator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("list")]
        public IActionResult GetAllBoards()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllBoardsByUserId()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("statistics")]
        public IActionResult GetBoardsStatistics()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult GetBoardById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateBoard([FromBody] BoardCreateDTO BoardData)
        {
            var validationResult = _createBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateBoard([FromBody] BoardUpdateDTO BoardData)
        {
            var validationResult = _updateBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public IActionResult DeleteBoard(int id)
        {
            return Ok();
        }
    }
}
