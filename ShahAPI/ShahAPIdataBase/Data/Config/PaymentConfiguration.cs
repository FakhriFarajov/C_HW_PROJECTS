using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.PaymentStatus)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.TransactionId)
            .HasMaxLength(255); // Assuming a GUID or similar length for transaction ID.

        builder.Property(p => p.PaidAt)
            .IsRequired(false); // Nullable DateTime

        builder.HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // If an order is deleted, its payment should also be deleted.
    }
}
