namespace TechnicalTestBackendProject.Models
{
    public enum Role
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
        public Role UserRole { get; set; }
        public ICollection<BoardModel>? Boards { get; set; }
    }
}
