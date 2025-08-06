using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Config;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Quantity).IsRequired();
        builder.Property(ci => ci.AddedAt).IsRequired();

        builder.HasOne(ci => ci.User)
               .WithMany()
               .HasForeignKey(ci => ci.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.Product)
               .WithMany()
               .HasForeignKey(ci => ci.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
