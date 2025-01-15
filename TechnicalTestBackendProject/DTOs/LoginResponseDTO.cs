namespace TechnicalTestBackendProject.DTOs
{
    public class LoginResponseDTO
    {
        public UserReadDTO User { get; set; }
        public string Token { get; set; }
    }
}
