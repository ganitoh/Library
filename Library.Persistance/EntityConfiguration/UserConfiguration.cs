using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u=>u.Login).IsRequired().HasMaxLength(120);
            builder.Property(u=>u.PasswordHash).IsRequired();
            builder.Property(u=>u.RoleId).IsRequired();

            builder
                .HasMany(u => u.Books)
                .WithMany(u => u.Users);

        }
    }
}
