using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<UserReadDTO> Signup(UserCreateDTO userCreateDTO);

        Task<UserReadDTO> Login(UserCreateDTO userLoginDTO);
        Task<UserReadDTO> Logout();

    }
}
