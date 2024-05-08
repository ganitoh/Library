using Library.Domain.Models;
using Library.Persistance.Exception;
using Library.Persistance.Services.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Services.Repositories.Emplementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateEntityAsync(Book entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<Book> GetEntityAsync(Guid id)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b=>b.Id == id);

            if (book is null)
                throw new EntityNotFoundException("bool not found");

            return book;
            
        }
        public async Task<IEnumerable<Book>> GetAllEntitiesAsync()
            => await _context.Books.AsNoTracking().ToListAsync();

        public async Task DeleteEntityAsync(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book is null)
                throw new EntityNotFoundException("bool not found");

           _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
