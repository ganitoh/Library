namespace Library.Persistance.Services.Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateEntityAsync(TEntity entity);
        Task<TEntity> GetEntityAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task DeleteEntityAsync(Guid id);
    }
}
