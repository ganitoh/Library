namespace Library.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public byte[]? ImageByte { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int PageCount { get; set; }
        public Author? Author { get; set; }
        public User? User  { get; set; }

        public override string ToString() =>
            $"книга-{Title} автор-{Author?.Name ?? "not info"}";

    }
}
