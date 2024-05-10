using Library.Domain.Models;
using Library.Persistance.Exception;
using Library.Persistance.Services.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Services.Repositories.Emplementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateEntityAsync(User entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<User> GetEntityAsync(Guid id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new EntityNotFoundException("user not found");

            return user;

        }
        public async Task<IEnumerable<User>> GetAllEntitiesAsync()
            => await _context.Users.AsNoTracking().ToListAsync();

        public async Task DeleteEntityAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(b => b.Id == id);

            if (user is null)
                throw new EntityNotFoundException("user not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
