using DueDinariAmico.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DueDinariAmico.Infrastructure.Configuration;

public class DeletableTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class, ISoftDeletable
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasQueryFilter(e => e.IsDeleted == false);

        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false);
    }
}