using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations.ShahAPIDataBase.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.Status)
            .IsRequired()
            .HasMaxLength(50); // e.g., Pending, Completed, Shipped

        builder.Property(o => o.CreatedAt)
            .IsRequired();

        builder.HasOne(o => o.Buyer)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict); // Keep order history even if user is deleted

        builder.HasOne(o => o.ShippingAddress)
            .WithMany() // Assuming Address can be used by many orders, but an order has only one shipping address, and Address itself doesn't explicitly list Orders.
            .HasForeignKey(o => o.ShippingAddressId)
            .OnDelete(DeleteBehavior.Restrict); // Don't delete address if it's tied to an order.

        builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Payment)
            .WithOne(p => p.Order)
            .HasForeignKey<Payment>(p => p.OrderId)
            .IsRequired(false) // Payment can be null initially
            .OnDelete(DeleteBehavior.SetNull); // Payment might be deleted if order is, or set to null. SetNull is safer.
    }
}