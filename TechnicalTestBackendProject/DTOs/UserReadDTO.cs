using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string? BoardId { get; set; }
        public BoardReadDTO? Board { get; set; }
        public TaskState TaskState { get; set; }
    }
}
