using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Domain.Events;

public class OrderUpdated : DomainEvent
{
    public OrderUpdated(Order order)
    {
        Order = order;
    }

    public Order Order { get; set; }
}
