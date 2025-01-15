using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;
using System.Threading;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;
        private readonly IMapper _mapper;

        public BoardRepository(ApplicationDbContext context, IConnectionMultiplexer redis, IMapper mapper)
        {
            _dbContext = context;
            _redis = redis;
            _cache = redis.GetDatabase();
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoardReadDTO>> GetAllBoardsAsync()
        {
            // Check if boards are on cache
            var cacheBoards = _cache.StringGet("Boards");
            if (cacheBoards.HasValue)
            {
                return JsonSerializer.Deserialize<IEnumerable<BoardReadDTO>>(cacheBoards);
            }

            // If boards are nor on cache 
            var boards = await _dbContext.Boards.ToListAsync();

            _cache.StringSet("Boards", JsonSerializer.Serialize(boards));

            return boards.Select(board => _mapper.Map<BoardReadDTO>(board));
        }

        public async Task<BoardReadDTO> GetBoardByIdAsync(int id)
        {
            // Check if the board is in the cache
            var cacheBoard = _cache.StringGet($"Board:{id}");
            if (cacheBoard.HasValue)
            {
                return JsonSerializer.Deserialize<BoardReadDTO>(cacheBoard);
            }

            // If the board is not in the cache, get it from the database
            var board = await _dbContext.Boards.FindAsync(id);
            if (board != null)
            {
                _cache.StringSet($"Board:{board.Id}", JsonSerializer.Serialize(board));
            }

            var BoardReadDTO = _mapper.Map<BoardReadDTO>(board);

            return BoardReadDTO;
        }
        public async Task<BoardReadDTO> AddBoardAsync(BoardCreateDTO entity)
        {
            var newBoard = _mapper.Map<BoardModel>(entity);

            await _dbContext.Boards.AddAsync(newBoard);
            await _dbContext.SaveChangesAsync();

            // Updating Redis Cache
            _cache.StringSet($"Board:{newBoard.Id}", JsonSerializer.Serialize(newBoard));

            var BoardReadDTO = _mapper.Map<BoardReadDTO>(newBoard);

            return BoardReadDTO;
        }


        public async Task<BoardReadDTO> UpdateBoardAsync(BoardUpdateDTO entity)
        {
            var boardToUpdate = await _dbContext.Boards.FindAsync(entity.Id);
            //var taskToUpdate = await _dbContext.Boards.FindAsync(new object[] {request.Id}, cancellationToken);

            if (boardToUpdate == null)
            {
                return null;
            }

            boardToUpdate.Name = entity.Name;
            boardToUpdate.Description = entity.Description;

            boardToUpdate = _mapper.Map<BoardUpdateDTO, BoardModel>(entity, boardToUpdate);

            await _dbContext.SaveChangesAsync();

            // Updatin Redis Cache
            _cache.StringSet($"Board:{boardToUpdate.Id}", JsonSerializer.Serialize(boardToUpdate));

            var BoardReadDTO = _mapper.Map<BoardReadDTO>(boardToUpdate);

            return BoardReadDTO;
        }
        public async Task<bool> DeleteBoardAsync(int id)
        {
            var boardToDelete = await _dbContext.Boards.FindAsync(id);
            //var boardToDelete = await _dbContext.Boards.FindAsync(new object[] { request.Id }, cancellationToken);

            if (boardToDelete == null)
            {
                return false;
            }

            _dbContext.Boards.Remove(boardToDelete);
            await _dbContext.SaveChangesAsync();

            // Deleting from Redis Cache
            _cache.KeyDelete($"Board:{boardToDelete.Id}");

            return true;
        }

        public async Task<IEnumerable<BoardReadDTO>> GetBoardsByUserIdAsync(int userId)
        {
            var boards = await _dbContext.Boards
                .Where(board => board.CreatedById == userId)
                .ToListAsync();

            return boards.Select(board => _mapper.Map<BoardReadDTO>(board));
        }

        public async Task<IEnumerable<BoardStatisticsDTO>> GetStatisticsAsync(int userId)
        {
            //return await _dbContext.Tasks
            //    .Where(t => t.Board.CreatedById == userId.ToString())
            //    .GroupBy(t => t.TaskStatus)
            //    .Select(g => new TaskStatisticsDTO
            //    {
            //        Status = g.Key.ToString(),
            //        Count = g.Count()
            //    })
            //    .ToListAsync();

            //return await _dbContext.Tasks
            //        .Where(t => t.Board.CreatedById == userId.ToString())
            //        .GroupBy(t => new { t.BoardId, t.Board.Name, t.TaskStatus })
            //        .Select(g => new TaskStatisticsDTO
            //        {
            //            BoardId = int.Parse(g.Key.BoardId),
            //            BoardName = g.Key.Name,
            //            Status = g.Key.TaskStatus.ToString(),
            //            Count = g.Count()
            //        })
            //        .ToListAsync();

            var groupedStatistics = await _dbContext.Tasks
                    .Where(t => t.Board.CreatedById == userId)
                    .GroupBy(t => new { t.BoardId, t.Board.Name })
                    .Select(g => new BoardStatisticsDTO
                    {
                        BoardId = g.Key.BoardId,
                        BoardName = g.Key.Name,
                        Statistics = g.GroupBy(t => t.TaskStatus.ToString())
                                      .Select(s => new TaskStatisticsDTO
                                      {
                                          Status = s.Key,
                                          Count = s.Count()
                                      })
                                      .ToList()
                    })
                    .ToListAsync();

            return groupedStatistics;
        }
    }
}
