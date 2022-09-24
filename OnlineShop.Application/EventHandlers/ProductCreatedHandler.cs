using MediatR;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.EventHandlers;
public class ProductCreatedHandler : INotificationHandler<DomainEventNotification<ProductCreated>>
{
    private readonly IReadRepository<Domain.Entities.Products.Product> _productReadRepository;

    public ProductCreatedHandler(IReadRepository<Domain.Entities.Products.Product> productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task Handle(DomainEventNotification<ProductCreated> notification, CancellationToken cancellationToken)
    {
        var product = notification.DomainEvent.Product;
        product.Id = 0;

        await _productReadRepository.Add(product, cancellationToken);

        await _productReadRepository.SaveChanges(cancellationToken);
    }
}

