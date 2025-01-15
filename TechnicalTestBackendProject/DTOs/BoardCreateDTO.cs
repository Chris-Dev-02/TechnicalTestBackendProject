namespace TechnicalTestBackendProject.DTOs
{
    public class BoardCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CreatedById { get; set; }
    }
}
