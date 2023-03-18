///<summary>
///Command for deleting an order.
/// </summary>
using MediatR;

namespace OnlineShop.Application.Order.Commands.DeleteOrder;
public class DeleteOrderCommand : IRequest
{
    public DeleteOrderCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
