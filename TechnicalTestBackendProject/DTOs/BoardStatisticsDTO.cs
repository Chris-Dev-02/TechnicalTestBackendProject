namespace TechnicalTestBackendProject.DTOs
{
    public class BoardStatisticsDTO
    {
        public int BoardId { get; set; }
        public string BoardName { get; set; } = string.Empty;
        public List<TaskStatisticsDTO> Statistics { get; set; } = new();
    }
}
