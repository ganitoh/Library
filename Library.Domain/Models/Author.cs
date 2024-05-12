namespace Library.Domain.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public Guid FullNameId { get; set; }
        public FIO FullName { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = [];
    }
}
