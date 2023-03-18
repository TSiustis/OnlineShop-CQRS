///<summary>
///Domain event to keep the read schema in sync when a order is created on the write schema.
/// </summary>
using MediatR;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;
using Order = OnlineShop.Domain.Entities.Orders.Order;

public class OrderCreatedHandler : INotificationHandler<DomainEventNotification<OrderCreated>>
{
    private readonly IReadRepository<Order> _readOrderRepository;

    public OrderCreatedHandler(IReadRepository<Order> readRepository)
    {
        _readOrderRepository = readRepository;
    }

    public async Task Handle(DomainEventNotification<OrderCreated> notification, CancellationToken cancellationToken)
    {
        var order = notification.DomainEvent.Order;
        order.Id = 0;

        foreach(var item in order.Items)
        {
            item.Id = 0;
        }

        await _readOrderRepository.Add(order, cancellationToken);

        await _readOrderRepository.SaveChanges(cancellationToken);
    }
}

