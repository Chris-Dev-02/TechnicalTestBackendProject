using TechnicalTestBackendProject.DTOs;

namespace TechnicalTestBackendProject.Repository
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserByUsername(string username);
        Task<UserDTO> GetUserByEmail(string email);
    }
}
