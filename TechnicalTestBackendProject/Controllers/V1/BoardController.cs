using FluentValidation;
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
        public IActionResult CreateBoard([FromBody] BoardCreateDTO BoardData)
        {
            var validationResult = _createBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBoard([FromBody] BoardUpdateDTO BoardData)
        {
            var validationResult = _updateBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

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
