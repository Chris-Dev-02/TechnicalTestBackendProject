using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;
using TechnicalTestBackendProject.Services.Interfaces;

namespace TechnicalTestBackendProject.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<IEnumerable<Role>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDTO> Login(UserCreateDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDTO> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDTO> Signup(UserCreateDTO userCreateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
