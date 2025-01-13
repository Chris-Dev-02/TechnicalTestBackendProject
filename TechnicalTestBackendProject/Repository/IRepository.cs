namespace TechnicalTestBackendProject.Repository
{
    public interface IRepository<TRead, TCreate, TUpdate> 
        where TRead : class
        where TCreate : class
        where TUpdate : class
    {
        Task<IEnumerable<TRead>> GetAllAsync();
        Task<TRead> GetByIdAsync(int id);
        Task<TRead> AddAsync(TCreate entity);
        Task<TRead> UpdateAsync(TUpdate entity);
        Task<bool> DeleteAsync(int id);
    }
}
