using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IValidator<BoardCreateDTO> _createBoardValidator;
        private readonly IValidator<BoardUpdateDTO> _updateBoardValidator;
        private readonly IBoardService _boardService;

        public BoardController(
            IValidator<BoardCreateDTO> createBoardValidator, 
            IValidator<BoardUpdateDTO> updateBoardValidator,
            IBoardService boardService)
        {
            _createBoardValidator = createBoardValidator;
            _updateBoardValidator = updateBoardValidator;
            _boardService = boardService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllBoards()
        {
            var boards = _boardService.GetAllBoardsAsync();
            return Ok(boards);
        }

        [HttpGet]
        [Authorize]
        [Route("user/{id}")]
        public async Task<IActionResult> GetBoardsByUserId(int userId)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId == null || int.Parse(currentUserId) != userId) return Unauthorized();

            //var boards = _boardService.GetAllBoardsByUserAsync(userId);
            var boards = await _boardService.GetAllBoardsByUserAsync(userId);
            return Ok(boards);
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();

            var board = _boardService.GetBoardByIdAsync(id, int.Parse(userId));
            if (board == null) NotFound();

            return Ok(board);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBoard([FromBody] BoardCreateDTO BoardData)
        {
            var validationResult = _createBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();
            BoardData.CreatedById = userId;

            var board = await _boardService.CreateBoardAsync(BoardData);

            return Ok(board);
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateBoard([FromBody] BoardUpdateDTO BoardData)
        {
            var validationResult = _updateBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();

            var board = _boardService.UpdateBoardAsync(BoardData, int.Parse(userId));
            if (board == null) NotFound();

            return Ok(board);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var result = await _boardService.DeleteBoardAsync(id, int.Parse(userId));
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
