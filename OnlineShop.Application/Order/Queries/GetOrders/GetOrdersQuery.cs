using MediatR;
using OnlineShop.Application.Order.Dto;

namespace OnlineShop.Application.Order.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<IList<OrderDto>>
    {

    }
}
