using System.Text.Json.Serialization;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class UserAuthDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleEnum UserRole { get; set; }
        public string? Password { get; set; }
    }
}
