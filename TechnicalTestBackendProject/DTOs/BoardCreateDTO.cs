namespace TechnicalTestBackendProject.DTOs
{
    public class BoardCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string? CreatedById { get; set; }
    }
}
