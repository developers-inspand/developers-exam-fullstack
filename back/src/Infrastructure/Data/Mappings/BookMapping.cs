using Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class BookMapping : EntityTypeConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.ToTable("Books");

        builder.Property(b => b.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasMaxLength(100);

        builder.Property(b => b.Author)
            .IsRequired()
            .HasColumnName("Author")
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasMaxLength(1024);

    }
}
