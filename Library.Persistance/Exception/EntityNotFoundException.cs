
namespace Library.Persistance.Exception
{
    public class EntityNotFoundException  : System.Exception
    {
        public EntityNotFoundException(string message)
            : base(message) { }
    }
}
