using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string[]> GetAllRoles();
        Task<UserReadDTO> Signup(UserCreateDTO userCreateDTO);
        Task<string> Login(LoginDTO userLoginDTO);
        Task AssignRole(AssignRoleDTO assignRoleDTO);
        Task<UserReadDTO> Logout();

    }
}
