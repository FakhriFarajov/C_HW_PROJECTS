using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Config;

public class CategoryPropertyConfiguration : IEntityTypeConfiguration<CategoryProperty>
{
    public void Configure(EntityTypeBuilder<CategoryProperty> builder)
    {
        builder.ToTable("CategoryProperties");
        builder.HasKey(cp => cp.Id);
        builder.Property(cp => cp.Name).IsRequired().HasMaxLength(100);
        builder.Property(cp => cp.CategoryId).IsRequired();

        builder.HasOne(cp => cp.Category)
               .WithMany(c => c.Properties)
               .HasForeignKey(cp => cp.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
