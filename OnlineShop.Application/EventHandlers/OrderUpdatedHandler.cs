///<summary>
///Domain event to keep the read schema in sync when a order is updated on the write schema.
/// </summary>
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
        _readOrderRepository.Update(notification.DomainEvent.Order);

        await _readOrderRepository.SaveChanges(cancellationToken);
    }
}
