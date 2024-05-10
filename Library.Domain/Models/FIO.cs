namespace Library.Domain.Models
{
    public class FIO
    {
        public string FiratName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Patronumic { get; set; } = string.Empty;

        public FIO() { }

        public FIO(string firatName, string lastName)
        {
            FiratName = firatName;
            LastName = lastName;
        }

        public FIO(string firatName, string lastName, string patronumic) 
            : this (firatName,lastName)
        {
            Patronumic = patronumic;
        }
    }
}
