using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class TaskCreateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int BoardId { get; set; }
        public int TaskId { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
    }
}
