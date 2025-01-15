using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class TaskStatisticsDTO
    {
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.ToDo;
        public int Count { get; set; }
    }
}
