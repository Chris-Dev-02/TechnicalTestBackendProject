namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface ICRUDService<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);
    }
}
