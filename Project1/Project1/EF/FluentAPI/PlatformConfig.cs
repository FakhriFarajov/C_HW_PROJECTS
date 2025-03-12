namespace Project1.EF.FluentAPIConfig;

using Project1.EF.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlatformConfig: IEntityTypeConfiguration<Platform> 
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(x => x.Games).WithOne(x => x.Platform).HasForeignKey(x => x.PlatformId);
    }
}