using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;
using TechnicalTestBackendProject.Data;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Repository
{
    public class UserRepository : IRepository<UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _cache;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IConnectionMultiplexer redis, IMapper mapper)
        {
            _dbContext = context;
            _redis = redis;
            _cache = redis.GetDatabase();
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllAsync()
        {
            // Check if the data is in the cache
            var cachedUsers = await _cache.StringGetAsync("Users");
            if (cachedUsers.HasValue)
            {
                return JsonSerializer.Deserialize<IEnumerable<UserReadDTO>>(cachedUsers);
            }

            // If the data is not in the cache
            var users = await _dbContext.Users.ToListAsync();

            await _cache.StringSetAsync("Users", JsonSerializer.Serialize(users));

            return users.Select(user => _mapper.Map<UserReadDTO>(user));
        }

        public async Task<UserReadDTO> GetByIdAsync(int id)
        {
            // Check if the data is in the cache
            var cachedUser = _cache.StringGet($"User:{id}");
            if (cachedUser.HasValue)
            {
                return JsonSerializer.Deserialize<UserReadDTO>(cachedUser);
            }

            // If the data is not in the cache, get it from the database
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _cache.StringSet($"User:{user.Id}", JsonSerializer.Serialize(user));
            }

            var UserReadDTO = _mapper.Map<UserReadDTO>(user);

            return UserReadDTO;
        }

        public async Task<UserReadDTO> AddAsync(UserCreateDTO entity)
        {
            var newUser = _mapper.Map<UserModel>(entity);

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            // Add the new user to the cache
            await _cache.StringSetAsync($"User:{newUser.Id}", JsonSerializer.Serialize(newUser));

            var UserReadDTO = _mapper.Map<UserReadDTO>(newUser);

            return UserReadDTO;
        }

        public async Task<UserReadDTO> UpdateAsync(UserUpdateDTO entity)
        {
            var userToUpdate = await _dbContext.Users.FindAsync(entity.Id);

            if (userToUpdate == null)
            {
                return null;
            }

            userToUpdate = _mapper.Map<UserUpdateDTO, UserModel>(entity, userToUpdate);

            await _dbContext.SaveChangesAsync();

            // Update the user in the cache
            await _cache.StringSetAsync($"User:{userToUpdate.Id}", JsonSerializer.Serialize(userToUpdate));

            var UserReadDTO = _mapper.Map<UserReadDTO>(userToUpdate);

            return UserReadDTO;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userToDelete = _dbContext.Users.Find(id);

            if (userToDelete == null) {
                return false;
            }

            _dbContext.Users.Remove(userToDelete);
            _dbContext.SaveChanges();

            // Delete the user from the cache
            _cache.KeyDelete($"User:{id}");

            return true;
        }
    }
}
