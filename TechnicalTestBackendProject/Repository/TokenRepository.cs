using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace TechnicalTestBackendProject.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;

        public TokenRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _cache = _redis.GetDatabase();
        }

        public async Task<bool> InvalidateTokenAsync(string token)
        {
            var expirationTime = TimeSpan.FromHours(1);
            await _cache.StringSetAsync($"invalid_token:{token}", "invalid", expirationTime);
            var value = await _cache.StringGetAsync($"invalid_token:{token}");
            return !value.IsNullOrEmpty;
        }

        public async Task<bool> IsTokenValidAsync(string token)
        {
            var value = await _cache.StringGetAsync($"invalid_token:{token}");
            return value.IsNullOrEmpty;
        }
    }
}
