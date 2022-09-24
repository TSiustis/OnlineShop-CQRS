using MediatR;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.EventHandlers;

public class ProductUpdatedHandler : INotificationHandler<DomainEventNotification<ProductUpdated>>
{
    private readonly IReadRepository<Domain.Entities.Products.Product> _productReadRepository;

    public ProductUpdatedHandler(IReadRepository<Domain.Entities.Products.Product> productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task Handle(DomainEventNotification<ProductUpdated> notification, CancellationToken cancellationToken)
    {
        _productReadRepository.Update(notification.DomainEvent.Product, cancellationToken);

        await _productReadRepository.SaveChanges(cancellationToken);
    }
}
