using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Domain.Events;

public class OrderCreated : DomainEvent
{
    public OrderCreated(Order order)
    {
        Order = order;
    }

    public Order Order { get; set; }
}

