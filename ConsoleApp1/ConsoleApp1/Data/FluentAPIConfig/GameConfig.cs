namespace Project1.Data.FluentAPIConfig;

using Project1.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GameConfig: IEntityTypeConfiguration<Game> 
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasOne(x => x.Genre).WithMany(x => x.Games).HasForeignKey(x => x.GenreId);
        builder.Property(x => x.GenreId).IsRequired();
        builder.HasOne(x => x.Platform).WithMany(x => x.Games).HasForeignKey(x => x.PlatformId);
        builder.Property(x => x.PlatformId).IsRequired();
        builder.Property(x => x.Price).IsRequired();
    }
}