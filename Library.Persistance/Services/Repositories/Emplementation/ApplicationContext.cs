using Library.Domain.Models;
using Library.Persistance.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Services.Repositories.Emplementation
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<SuggestedBook> BooksSuggestedUser { get; set; }
        public ApplicationContext(DbContextOptions options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
