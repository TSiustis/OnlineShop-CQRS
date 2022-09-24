using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Infrastructure.Persistence.EntityConfigurations;
public class  OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();
        builder.Ignore(o => o.DomainEvents);

        builder.OwnsOne(o => o.Address);

        builder.Property(o => o.Amount)
            .IsRequired();

        builder.Property(o => o.OrderedAt)
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.UtcNow);

        builder.Property(o => o.Status)
            .HasConversion<byte>()
            .IsRequired()
            .HasDefaultValue(OrderStatus.New);

        builder.Property(o => o.PaymentType)
            .HasConversion<byte>()
            .IsRequired()
            .HasDefaultValue(PaymentType.Usd);

        builder.Property(o => o.ShippedAt)
            .IsRequired();

        var navigation = builder.Metadata.FindNavigation(nameof(Order.Items));

        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Ignore(o => o.DomainEvents);

    }
}
