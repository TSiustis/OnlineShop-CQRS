namespace OnlineShop.Domain.Events;

using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Customers;

public class CustomerCreated : DomainEvent
{
    public CustomerCreated(Customer customer)
    {
        Customer = customer;
    }
    public Customer Customer { get; set; }
}

