namespace Library.Domain.Models
{
    public class User : Person
    {
        public int Age { get; set; }
        public long Phone { get; set; }
        public byte[]? AvatarImageByte { get; set; }
        public string? email { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
