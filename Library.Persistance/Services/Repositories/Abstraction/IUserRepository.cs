using Library.Domain.Models;

namespace Library.Persistance.Services.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<User> GetEntityAsync(string login);
    }
}
