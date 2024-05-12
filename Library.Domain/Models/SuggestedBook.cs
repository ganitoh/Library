namespace Library.Domain.Models
{
    public class SuggestedBook
    {
        public Guid Id { get; set; }
        public string NameBook { get; set; } = string.Empty;
        public FIO? AuthoData { get; set; }
        public int SuggestByUserid { get; set; }
        public User SuggetsByUser { get; set; } = null!;

    }
}
