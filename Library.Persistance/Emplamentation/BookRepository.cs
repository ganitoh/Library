using Library.Domain.Models;
using Library.Persistance.Intarfaces;

namespace Library.Persistance.Emplamentation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context = null!;

        public BookRepository()
        {
            _context = new ApplicationContext();
        }

        public bool Add(Book entity)
        {
            if (entity is  null) 
                throw new ArgumentNullException(nameof(entity));

            _context.Books.Add(entity);

            if (_context.SaveChanges() > 0)
                return true;
            else 
                return false;
            
        }

        public Book? Get(int id) =>
              _context.Books.FirstOrDefault<Book>(book => book.Id == id);

        public IEnumerable<Book>? GetAll()=>
            _context.Books.ToList();

        public bool Delete(Book entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _context.Books.Remove(entity);

            if (_context.SaveChanges() > 0 )
                return true;
            else 
                return false;
        }


        public bool Update(Book entity)
        {
            if(entity is null)
                throw new ArgumentNullException(nameof(entity));

            var book = _context.Books.FirstOrDefault<Book>(book => book.Id == entity.Id);

            if (book is not null)
            {
                book = entity;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
