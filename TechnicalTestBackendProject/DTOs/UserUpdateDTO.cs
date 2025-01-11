using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role UserRole { get; set; }
    }
}
