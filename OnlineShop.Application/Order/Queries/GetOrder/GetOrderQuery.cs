///<summary>
///Query for retrieving an order.
/// </summary>
namespace OnlineShop.Application.Order.Queries.GetOrder
{
    using MediatR;
    using OnlineShop.Application.Order.Dto;

    public class GetOrderQuery : IRequest<OrderDto>
    {
        public GetOrderQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
