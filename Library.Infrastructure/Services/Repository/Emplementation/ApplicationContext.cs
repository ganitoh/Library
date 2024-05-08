using Microsoft.EntityFrameworkCore;


namespace Library.Persistance.Services.Repository.Emplementation
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

    }
}
