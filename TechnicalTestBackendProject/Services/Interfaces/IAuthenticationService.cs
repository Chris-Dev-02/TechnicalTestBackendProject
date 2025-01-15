using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string[]> GetAllRoles();
        Task<UserReadDTO> Signup(UserCreateDTO userCreateDTO);
        Task<LoginResponseDTO> Login(LoginDTO userLoginDTO);
        Task AssignRole(AssignRoleDTO assignRoleDTO);
        Task<bool> Logout(string token);
        Task<bool> IsValidToken(string token);

        //Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        //Task<UserReadDTO> GetUserByIdAsync(int id, int userId);
        //Task<UserReadDTO> CreateUserAsync(UserCreateDTO entity);
        //Task<UserReadDTO> UpdateUserAsync(UserUpdateDTO entity);
        //Task<bool> DeleteUserAsync(int id);

    }
}
