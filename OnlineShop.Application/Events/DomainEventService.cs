///<summary>
///Service for raising domain events.
/// </summary>
namespace OnlineShop.Application.Events;

using System.Diagnostics;
    using MediatR;
    using OnlineShop.Domain.Common;
    using OnlineShop.Domain.Interfaces;

    public class DomainEventService : IDomainEventService
    {
        private readonly IMediator _mediator;

        public DomainEventService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Raise(DomainEvent domainEvent, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Raising domain event. Event - {event}", domainEvent.GetType().Name);
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent), cancellationToken);
        }

        private static INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
