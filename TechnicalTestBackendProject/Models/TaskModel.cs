using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTestBackendProject.Models
{
    public enum TaskStatusEnum
    {
        ToDo = 1,
        InProgress = 2,
        Done = 3
    }
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string? BoardId { get; set; }
        [ForeignKey("BoardId")]
        public BoardModel? Board { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
    }
}
