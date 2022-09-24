using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Customers;

namespace OnlineShop.Domain.Events;

public class CustomerUpdated : DomainEvent
{
    public Customer Customer { get; set; }

    public CustomerUpdated(Customer customer)
    {
        Customer = customer;
    }
}


