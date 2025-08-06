using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Config;

public class ProductPropertiesValueConfiguration : IEntityTypeConfiguration<ProductPropertiesValue>
{
    public void Configure(EntityTypeBuilder<ProductPropertiesValue> builder)
    {
        builder.ToTable("ProductPropertiesValues");
        builder.HasKey(ppv => ppv.Id);
        builder.Property(ppv => ppv.Value).IsRequired().HasMaxLength(255);
        builder.Property(ppv => ppv.ProductId).IsRequired();
        builder.Property(ppv => ppv.CategoryPropertyId).IsRequired();

        builder.HasOne(ppv => ppv.Product)
               .WithMany(p => p.ProductPropertiesValues)
               .HasForeignKey(ppv => ppv.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ppv => ppv.CategoryProperty)
               .WithMany()
               .HasForeignKey(ppv => ppv.CategoryPropertyId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
