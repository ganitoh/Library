using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Persistance.Services.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateEntityAsync(TEntity entity);
        Task<TEntity> GetEntityAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllEntitiesAsync();
        Task DeleteEntityAsync(Guid id);
    }
}
