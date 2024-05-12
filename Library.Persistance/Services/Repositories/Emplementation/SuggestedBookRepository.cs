using Library.Domain.Models;
using Library.Persistance.Exception;
using Library.Persistance.Services.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Services.Repositories.Emplementation
{
    public class SuggestedBookRepository(ApplicationContext _context) 
        : ISuggestedBookRepository
    {

        public async Task CreateEntityAsync(SuggestedBook entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.BooksSuggestedUser.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(Guid id)
        {
            var bookInfo = await _context.BooksSuggestedUser
                .FirstOrDefaultAsync(b=>b.Id == id) ?? 
                throw new EntityNotFoundException("book not found");

            _context.BooksSuggestedUser.Remove(bookInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SuggestedBook>> GetAllEntitiesAsync()
            => await _context.BooksSuggestedUser.AsNoTracking().ToListAsync();

        public async Task<SuggestedBook> GetEntityAsync(Guid id)
        {
            var bookInfo = await _context.BooksSuggestedUser
                .FirstOrDefaultAsync(b => b.Id == id) ??
                throw new EntityNotFoundException("book not found");

            return bookInfo;
        }
    }
}
