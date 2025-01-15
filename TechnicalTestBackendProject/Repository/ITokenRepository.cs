namespace TechnicalTestBackendProject.Repository
{
    public interface ITokenRepository
    {
        Task<bool> InvalidateTokenAsync(string token);
        Task<bool> IsTokenValidAsync(string token);
    }
}
