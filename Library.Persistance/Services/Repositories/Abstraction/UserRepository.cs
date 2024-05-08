using Library.Domain.Models;
using Library.Persistance.Exception;
using Library.Persistance.Services.Repositories.Emplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.Services.Repositories.Abstraction
{
    public class UserRepository : IUserRepository
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
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

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
