using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class TaskCreateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? BoardId { get; set; }
        public TaskStatusEnum TaskState { get; set; }
    }
}
