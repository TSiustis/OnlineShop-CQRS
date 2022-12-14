namespace OnlineShop.Application.Order.Commands.AddOrder;

using AutoMapper;
using MediatR;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>
{
    private readonly IWriteRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public AddOrderCommandHandler(IWriteRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.ShippedAt, request.Address, request.PaymentType, request.Status, request.Amount);

        foreach(var item in request.Items)
        {
            var orderItem = _mapper.Map<OrderItem>(item);

            order.AddOrderItem(orderItem.Product, orderItem.ProductPrice, orderItem.NumberOfProducts);
        }

        await _orderRepository.Add(order, cancellationToken);

        order.DomainEvents.Add(new OrderCreated(order));

        await _orderRepository.SaveChanges(cancellationToken);

        return await Unit.Task;
    }
}
