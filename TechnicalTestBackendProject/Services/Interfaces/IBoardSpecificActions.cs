namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface IBoardSpecificActions
    {
        Task GetAllBoardsByUser(int userId);
        Task GetStatistics();
    }
}
