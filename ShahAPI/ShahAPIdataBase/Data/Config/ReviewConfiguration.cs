using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Rating)
            .IsRequired();

        builder.Property(r => r.Comment)
            .HasMaxLength(500); // Assuming max length for comment

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.HasOne(r => r.Buyer)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.BuyerId)
            .OnDelete(DeleteBehavior.Restrict); // Keep review if buyer is deleted, but BuyerId becomes null or set to a generic user. Restrict is safer.

        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
