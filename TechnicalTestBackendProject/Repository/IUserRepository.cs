using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        Task<UserReadDTO> GetUserByIdAsync(int id);
        Task<UserReadDTO> AddUserAsync(UserCreateDTO entity);
        Task<UserReadDTO> UpdateUserAsync(UserUpdateDTO entity);
        Task<bool> DeleteUserAsync(int id);
        Task<UserDTO> GetUserByUsernameAsync(string username);
        Task<UserDTO> GetUserByEmailAsync(string email);
    }
}
