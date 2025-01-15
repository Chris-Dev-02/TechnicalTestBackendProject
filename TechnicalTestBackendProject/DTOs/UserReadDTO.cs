using System.Text.Json.Serialization;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserReadDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleEnum UserRole { get; set; }
        public ICollection<BoardDTO>? Boards { get; set; }
    }
}
