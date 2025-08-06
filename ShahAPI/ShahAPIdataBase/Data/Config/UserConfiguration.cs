using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique(); // Email should be unique

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255); // Storing hash, so needs to be long enough

        builder.Property(u => u.ImageUrl)
            .HasMaxLength(2048);

        builder.Property(u => u.Phone)
            .HasMaxLength(20);

        builder.Property(u => u.isConfirmed)
            .IsRequired();

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Products)
            .WithOne(p => p.Seller)
            .HasForeignKey(p => p.SellerId)
            .OnDelete(DeleteBehavior.Cascade); // If user is deleted, their products are deleted.

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.Buyer)
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict); // Keep order history if user is deleted, BuyerId might be set to null or a generic user.

        builder.HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Reviews)
            .WithOne(r => r.Buyer)
            .HasForeignKey(r => r.BuyerId)
            .OnDelete(DeleteBehavior.Restrict); // Keep reviews even if buyer is deleted.
        builder.HasMany(u => u.CartItems)
            .WithOne(ci => ci.User)
            .HasForeignKey(ci => ci.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(u => u.Favorites)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

