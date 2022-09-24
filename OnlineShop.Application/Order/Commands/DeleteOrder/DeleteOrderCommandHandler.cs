namespace OnlineShop.Application.Order.Commands.DeleteOrder;

using MediatR;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IWriteRepository<Order> _orderRepository;

    public DeleteOrderCommandHandler(IWriteRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        _orderRepository.Delete(request.Id);

        await _orderRepository.SaveChanges(cancellationToken);
        
        return await Unit.Task;
    }
}
