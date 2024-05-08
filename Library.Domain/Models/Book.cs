namespace Library.Domain.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CountPage { get; set; }
        public int AithorId { get; set; }
        public Author Author { get; set; } = null!;
        public DateTime DateWriting { get; set; }
        public List<User> Users { get; set; } = [];
    }
}
