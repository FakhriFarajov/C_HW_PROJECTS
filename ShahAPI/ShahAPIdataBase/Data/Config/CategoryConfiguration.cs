using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations.ShahAPIDataBase.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Products should not be deleted if category is deleted directly

        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.Subcategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Prevent circular cascade delete

        builder.HasMany(c => c.Properties)
            .WithOne(cp => cp.Category)
            .HasForeignKey(cp => cp.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); // Delete category properties if the category is deleted
    }
}