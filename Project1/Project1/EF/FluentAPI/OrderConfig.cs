namespace Project1.EF.FluentAPIConfig;

using Project1.EF.Models;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfig: IEntityTypeConfiguration<Order> 
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(u => u.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        builder.Property(x => x.Date).HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(x => x.TotalAmount).IsRequired();
    }
}