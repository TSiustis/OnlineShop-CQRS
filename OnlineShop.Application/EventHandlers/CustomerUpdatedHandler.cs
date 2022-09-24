using MediatR;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.EventHandlers;
public class CustomerUpdatedHandler : INotificationHandler<DomainEventNotification<CustomerUpdated>>
{
    private readonly IReadRepository<Domain.Entities.Customers.Customer> _customerReadRepository;

    public CustomerUpdatedHandler(IReadRepository<Domain.Entities.Customers.Customer> customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public async Task Handle(DomainEventNotification<CustomerUpdated> notification, CancellationToken cancellationToken)
    {
       _customerReadRepository.Update(notification.DomainEvent.Customer, cancellationToken);

       await _customerReadRepository.SaveChanges(cancellationToken);
    }
}