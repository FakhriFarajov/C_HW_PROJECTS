namespace Project1.Data.FluentAPIConfig;

using Project1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderPropConfig : IEntityTypeConfiguration<OrderProp>
{
    public void Configure(EntityTypeBuilder<OrderProp> builder)
    {
        builder.HasKey(op => op.Id);
        builder.Property(op => op.OrderId).IsRequired();
        builder.Property(op => op.GameId).IsRequired();
        builder.Property(op => op.Quantity).IsRequired();
        builder.Property(op => op.TotalPrice).IsRequired();

        builder.HasOne(op => op.Order)
            .WithMany(o => o.OrderProps)
            .HasForeignKey(op => op.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Ensures consistency when deleting an order

        builder.HasOne(op => op.Game)
            .WithMany(g => g.OrderProp)
            .HasForeignKey(op => op.GameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} // Prevents accidental deletion of games