namespace Project1.Data.FluentAPIConfig;

using Project1.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GameConfig : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name).IsRequired().HasMaxLength(100);
        builder.Property(g => g.GenreId).IsRequired();
        builder.Property(g => g.PlatformId).IsRequired();
        builder.Property(g => g.Price).IsRequired();
        builder.Property(g => g.Quantity).IsRequired();
        
        builder.HasOne(g => g.Genre)
            .WithMany(gen => gen.Games)
            .HasForeignKey(g => g.GenreId);
        
        builder.HasOne(g => g.Platform)
            .WithMany(p => p.Games)
            .HasForeignKey(g => g.PlatformId);
    }
}