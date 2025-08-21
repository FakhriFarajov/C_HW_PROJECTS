using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Surname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.PasswordHash)
            .IsRequired();

        builder.Property(s => s.ImageUrl)
            .HasMaxLength(500);

        builder.Property(s => s.Phone)
            .HasMaxLength(50);

        builder.Property(s => s.IsVerified)
            .IsRequired();

        builder.Property(s => s.CompanyName)
            .HasMaxLength(200);

        builder.Property(s => s.TaxId)
            .HasMaxLength(100);

        builder.Property(s => s.BankAccount)
            .HasMaxLength(100);

        builder.Property(s => s.Website)
            .HasMaxLength(200);

        // Relationships:

        // Seller has many Products
        builder.HasMany(s => s.Products)
            .WithOne(p => p.Seller)
            .HasForeignKey(p => p.SellerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seller has many Addresses
        builder.HasMany(s => s.Addresses)
            .WithOne(a => a.Seller)
            .HasForeignKey(a => a.SellerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Seller has many Orders
        builder.HasMany(s => s.Orders)
            .WithOne(o => o.Seller)
            .HasForeignKey(o => o.SellerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}