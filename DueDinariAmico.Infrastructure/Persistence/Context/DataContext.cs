using DueDinariAmico.Core.Entities;
using DueDinariAmico.Core.Interfaces;
using DueDinariAmico.Infrastructure.Configuration;
using DueDinariAmico.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DueDinariAmico.Infrastructure.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<ExchangeRateList> ExchangeRateLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ExchangeRateList>(ConfigureExchangeRateList);
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            builder.ApplyConfiguration<ISoftDeletable>(typeof(DeletableTypeConfiguration<>), entityType.ClrType);
        }
    }

    public void ConfigureExchangeRateList(EntityTypeBuilder<ExchangeRateList> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Currency);
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.Kup);
        builder.Property(x => x.Pro);
        builder.Property(x => x.Sre);
        builder.HasIndex(x => x.Id).IsUnique().HasFilter("[IsDeleted] != 1");
    }
}