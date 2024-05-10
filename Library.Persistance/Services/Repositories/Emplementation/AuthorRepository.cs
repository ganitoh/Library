using Library.Domain.Models;
using Library.Persistance.Exception;
using Library.Persistance.Services.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Services.Repositories.Emplementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateEntityAsync(Author entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Authors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetEntityAsync(Guid id)
        {
            var author = await _context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
                throw new EntityNotFoundException("author not found");

            return author;
        }
        public async Task<IEnumerable<Author>> GetAllEntitiesAsync()
            => await _context.Authors.AsNoTracking().ToListAsync();


        public async Task DeleteEntityAsync(Guid id)
        {
            var author = await _context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
                throw new EntityNotFoundException("author not found");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

        }
    }
}
