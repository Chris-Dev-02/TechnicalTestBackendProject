using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public RoleEnum UserRole { get; set; }
    }
}
