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
        [Required]
        public string? BoardId { get; set; }
        [ForeignKey("BoardId")]
        public BoardDTO? Board { get; set; }
        public TaskState TaskState { get; set; }
    }
}
