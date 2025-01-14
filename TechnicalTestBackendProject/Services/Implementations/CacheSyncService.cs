
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.Data;
using System.Threading.Tasks;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class CacheSyncService : BackgroundService
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;

        //public CacheSyncService(ApplicationDbContext dbContext, IDistributedCache cache)
        //{
        //    _dbContext = dbContext;
        //    _cache = cache;
        //}
        public CacheSyncService(ApplicationDbContext dbContext, IConnectionMultiplexer redis)
        {
            _dbContext = dbContext;
            _redis = redis;
            _cache = redis.GetDatabase();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Gets all data from PostgreSQL and syncs with Redis
                var users = await _dbContext.Users.ToListAsync();
                foreach (var user in users)
                {
                    string cacheKey = $"User:{user.Id}";
                    await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(user));
                }

                var boards = await _dbContext.Boards.ToListAsync();
                foreach (var board in boards)
                {
                    string cacheKey = $"Board:{board.Id}";
                    await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(board));
                }

                var tasks = await _dbContext.Tasks.ToListAsync();
                foreach (var task in tasks)
                {
                    string cacheKey = $"Task:{task.Id}";
                    await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(task));
                }

                Console.WriteLine("Syncing data...");

                // Sync data every 5 minutes
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
