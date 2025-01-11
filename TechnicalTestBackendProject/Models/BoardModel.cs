using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTestBackendProject.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string? CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public UserModel? CreatedBy { get; set; }
        public ICollection<TaskModel>? Tasks { get; set; }
    }
}
