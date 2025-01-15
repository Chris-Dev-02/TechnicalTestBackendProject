
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
        //private readonly ApplicationDbContext _dbContext;
        //private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        //public CacheSyncService(ApplicationDbContext dbContext, IDistributedCache cache)
        //{
        //    _dbContext = dbContext;
        //    _cache = cache;
        //}
        public CacheSyncService(
            //ApplicationDbContext dbContext, 
            IConnectionMultiplexer redis,
            IServiceScopeFactory serviceScopeFactory)
        {
            //_dbContext = dbContext;
            _redis = redis;
            _cache = redis.GetDatabase();
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    // Gets all data from PostgreSQL and syncs with Redis
                    var users = await dbContext.Users.ToListAsync();
                    foreach (var user in users)
                    {
                        string cacheKey = $"User:{user.Id}";
                        await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(user));
                    }

                    var boards = await dbContext.Boards.ToListAsync();
                    foreach (var board in boards)
                    {
                        string cacheKey = $"Board:{board.Id}";
                        await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(board));
                    }

                    var tasks = await dbContext.Tasks.ToListAsync();
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
}
