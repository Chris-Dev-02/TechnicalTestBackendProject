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
        public async Task<IActionResult> GetAllBoards()
        {
            var boards = await _boardService.GetAllBoardsAsync();
            return Ok(boards);
        }

        [HttpGet]
        [Authorize]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetBoardsByUserId(int userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null || int.Parse(currentUserId) != userId) return Unauthorized();

            //var boards = _boardService.GetAllBoardsByUserAsync(userId);
            var boards = await _boardService.GetAllBoardsByUserAsync(userId);
            return Ok(boards);
        }

        [HttpGet]
        [Authorize]
        [Route("statistics/{userId}")]
        public async Task<IActionResult> GetBoardsStatistics(int userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null || int.Parse(currentUserId) != userId) return Unauthorized();

            var statistics = await _boardService.GetStatisticsAsync(userId);
            return Ok(statistics);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> GetBoardById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();

            var board = await _boardService.GetBoardByIdAsync(id, int.Parse(userId));
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
            BoardData.CreatedById = int.Parse(userId);

            var board = await _boardService.CreateBoardAsync(BoardData);

            return Ok(board);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateBoard([FromBody] BoardUpdateDTO BoardData)
        {
            var validationResult = _updateBoardValidator.Validate(BoardData);

            if(validationResult.IsValid) {
                return BadRequest(validationResult.Errors);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) Unauthorized();

            var board = await _boardService.UpdateBoardAsync(BoardData, int.Parse(userId));
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
