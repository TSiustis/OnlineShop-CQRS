using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Customers;

namespace OnlineShop.Infrastructure.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder
            .Ignore(c => c.DomainEvents);

        builder
            .Property(c => c.FirstName)
            .IsRequired();

        builder
            .Property(c => c.LastName)
            .IsRequired();

        builder
            .Property(c => c.Email)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .IsRequired();

        builder
            .OwnsOne(c => c.Address);

        builder.Ignore(c => c.DomainEvents);
    }
}
