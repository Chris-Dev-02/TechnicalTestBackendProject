using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserAuthDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public RoleEnum UserRole { get; set; }
        public string? Password { get; set; }
    }
}
