namespace OnlineShop.Application.EventHandlers;

using MediatR;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

public class OrderUpdatedHandler : INotificationHandler<DomainEventNotification<OrderUpdated>>
{
    private readonly IReadRepository<Order> _readOrderRepository;

    public OrderUpdatedHandler(IReadRepository<Order> readRepository)
    {
        _readOrderRepository = readRepository;
    }

    public async Task Handle(DomainEventNotification<OrderUpdated> notification, CancellationToken cancellationToken)
    {
        _readOrderRepository.Update(notification.DomainEvent.Order, cancellationToken);

        await _readOrderRepository.SaveChanges(cancellationToken);
    }
}
