namespace Project1.Data.FluentAPIConfig;

using Project1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.UserId).IsRequired();
        builder.Property(o => o.Date).IsRequired();
        builder.Property(o => o.TotalAmount).IsRequired();
        
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        // Ensure OrderProps collection is correctly mapped
        builder.HasMany(o => o.OrderProps)
            .WithOne(op => op.Order)
            .HasForeignKey(op => op.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Ensures that deleting an Order removes related OrderProps
    }
}