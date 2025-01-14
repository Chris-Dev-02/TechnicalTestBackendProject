using System.Text.Json.Serialization;
using TechnicalTestBackendProject.Models;

namespace TechnicalTestBackendProject.DTOs
{
    public class AssignRoleDTO
    {
        public int UserId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))] 
        public RoleEnum UserRole { get; set; }
    }
}
