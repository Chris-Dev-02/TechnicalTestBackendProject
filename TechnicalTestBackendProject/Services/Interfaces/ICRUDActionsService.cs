namespace TechnicalTestBackendProject.Services.Interfaces
{
    public interface ICRUDActionsService<TRead, TCreate, TUpdate> 
        where TRead : class 
        where TCreate : class 
        where TUpdate : class
    {
        Task<IEnumerable<TRead>> Get();
        Task<TRead> GetById(int id);
        Task<TRead> Create(TCreate entity);
        Task<TRead> Update(TUpdate entity);
        Task<TRead> Delete(int id);
    }
}
