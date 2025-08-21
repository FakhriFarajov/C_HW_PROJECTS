using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShahAPIDataBase.Data.Models;

namespace ShahAPIDataBase.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            // Buyer relationship (optional)
            builder.HasOne(a => a.Buyer)
                .WithMany(b => b.Addresses)
                .HasForeignKey(a => a.BuyerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false); // Address can be unlinked or linked to Seller instead

            // Seller relationship (optional)
            builder.HasOne(a => a.Seller)
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false); // Address can be unlinked or linked to Buyer instead
        }
    }
}