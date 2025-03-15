namespace Project1.Data.FluentAPIConfig;


using Project1.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlatformConfig : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        
        builder.HasMany(p => p.Games)
            .WithOne(g => g.Platform)
            .HasForeignKey(g => g.PlatformId);
    }
}
