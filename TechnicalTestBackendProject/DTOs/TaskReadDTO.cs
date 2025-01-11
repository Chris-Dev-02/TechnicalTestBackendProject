using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class TaskReadDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Role UserRole { get; set; }
        public ICollection<BoardReadDTO>? Boards { get; set; }
    }
}
