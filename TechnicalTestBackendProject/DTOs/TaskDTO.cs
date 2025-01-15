using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int BoardId { get; set; }
        public BoardDTO? Board { get; set; }
        public int CreatedById { get; set; }
        public UserDTO? CreatedBy { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
    }
}
