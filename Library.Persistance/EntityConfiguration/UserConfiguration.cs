using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLitePCL;

namespace Library.Persistance.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name).HasMaxLength(50);
            builder.Property(user => user.Surname).HasMaxLength(50);
            builder.Property(user => user.Patronumic).HasMaxLength(50);

            builder.Property(user => user.Login).IsRequired();
            builder.Property(user => user.Password).IsRequired();
        }
    }
}
