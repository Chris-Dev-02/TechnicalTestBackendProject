using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class TaskReadDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string? BoardId { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
        public BoardDTO? Board { get; set; }
    }
}
