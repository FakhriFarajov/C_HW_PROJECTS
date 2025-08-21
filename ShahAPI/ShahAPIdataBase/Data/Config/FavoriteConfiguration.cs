using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Config;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.ToTable("Favorites");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.LikedAt).IsRequired();

        builder.HasOne(f => f.Buyer)
               .WithMany(u => u.Favorites)
               .HasForeignKey(f => f.BuyerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Product)
               .WithMany()
               .HasForeignKey(f => f.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
