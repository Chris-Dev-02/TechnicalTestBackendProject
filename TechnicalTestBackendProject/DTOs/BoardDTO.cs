using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTestBackendProject.DTOs
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string? CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public UserDTO? CreatedBy { get; set; }
        public ICollection<TaskDTO>? Tasks { get; set; }
    }
}
