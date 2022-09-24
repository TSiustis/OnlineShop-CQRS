namespace OnlineShop.Application.Order.Commands.UpdateOrder;

using AutoMapper;
using MediatR;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IWriteRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IWriteRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.ShippedAt, request.Address, request.PaymentType, request.Status, request.Amount);

        _orderRepository.Update(order);

        order.DomainEvents.Add(new OrderUpdated(order));

        await _orderRepository.SaveChanges(cancellationToken);

        return await Unit.Task;
    }
}
