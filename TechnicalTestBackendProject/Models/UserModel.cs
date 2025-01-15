using System.Text.Json.Serialization;

namespace TechnicalTestBackendProject.Models
{
    public enum RoleEnum
    {
        Admin = 1,
        User = 2
    }
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleEnum UserRole { get; set; } = RoleEnum.User;
        public ICollection<BoardModel>? Boards { get; set; }
        public ICollection<TaskModel>? Tasks { get; set; }
    }
}
