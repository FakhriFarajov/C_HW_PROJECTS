namespace Project1.EF.FluentAPIConfig;

using Project1.EF.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderPropConfig: IEntityTypeConfiguration<OrderProp> 
{
    public void Configure(EntityTypeBuilder<OrderProp> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OrderId).IsRequired();
        builder.Property(x => x.GameId).IsRequired();
        builder.HasOne(x => x.Game).WithMany(x => x.OrderProp).HasForeignKey(x => x.GameId);
        builder.HasOne(x => x.Order).WithMany(x => x.OrderProp).HasForeignKey(x => x.OrderId);
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.TotalPrice).IsRequired();


    }
}