using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r=>r.Id);
            builder.ToTable("Roles");

            builder.HasData(
                new Role() { Id = 1, Name = "admin" },
                new Role() { Id = 2, Name = "user" });
        }
    }
}
