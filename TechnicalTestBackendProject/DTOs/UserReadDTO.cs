using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public RoleEnum UserRole { get; set; }
        public ICollection<BoardDTO>? Boards { get; set; }
    }
}
