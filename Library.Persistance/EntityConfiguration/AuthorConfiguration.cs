using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistance.EntityConfiguration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a=>a.Id);

            builder
                .HasMany(a=>a.Books)
                .WithOne(a=>a.Author)
                .HasForeignKey(a=>a.AuthorId);

            builder
                .HasOne(a => a.FullName)
                .WithOne(f => f.Author)
                .HasForeignKey<FIO>(f=>f.AuthorId);
        }
    }
}
