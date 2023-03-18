///<summary>
///Handler for UpdateOrderCommand.
/// </summary>
namespace OnlineShop.Application.Order.Commands.UpdateOrder;

using MediatR;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IWriteRepository<Order> _orderRepository;

    public UpdateOrderCommandHandler(IWriteRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.Id, request.ShippedAt, request.Address, request.PaymentType, request.Status, request.Amount);

        _orderRepository.Update(order);

        order.DomainEvents.Add(new OrderUpdated(order));

        await _orderRepository.SaveChanges(cancellationToken);

        return await Unit.Task;
    }
}
