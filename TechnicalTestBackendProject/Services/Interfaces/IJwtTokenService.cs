using System.Security.Claims;
using TechnicalTestBackendProject.DTOs;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(UserDTO user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
