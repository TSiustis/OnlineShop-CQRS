///<summary>
///Domain event to keep the read schema in sync when a customer is added on the write schema.
/// </summary>
using MediatR;
using OnlineShop.Application.Events;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.EventHandlers;
public class CustomerCreatedHandler : INotificationHandler<DomainEventNotification<CustomerCreated>>
{
    private readonly IReadRepository<Domain.Entities.Customers.Customer> _customerReadRepository;

    public CustomerCreatedHandler(IReadRepository<Domain.Entities.Customers.Customer> customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public async Task Handle(DomainEventNotification<CustomerCreated> notification, CancellationToken cancellationToken)
    {
        var customer = notification.DomainEvent.Customer;
        customer.Id = 0;

        await _customerReadRepository.Add(customer, cancellationToken);

        await _customerReadRepository.SaveChanges(cancellationToken);
    }
}
