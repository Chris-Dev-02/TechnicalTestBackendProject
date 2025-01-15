namespace TechnicalTestBackendProject.DTOs
{
    public class BoardReadDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedById { get; set; }
        public UserReadDTO? CreatedBy { get; set; }
        public ICollection<TaskReadDTO>? Tasks { get; set; }
    }
}
