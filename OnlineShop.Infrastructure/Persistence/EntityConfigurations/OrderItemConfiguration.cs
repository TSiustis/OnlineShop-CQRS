﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Infrastructure.Persistence.EntityConfigurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Price)
            .IsRequired();

        builder
            .Property(o => o.Units)
            .IsRequired();

        builder
            .Ignore(o => o.DomainEvents);
    }
}