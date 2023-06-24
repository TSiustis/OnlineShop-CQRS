///<summary>
///Query for retrieving all orders.
/// </summary>
using MediatR;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Common.Pagination;

namespace OnlineShop.Application.Order.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<PaginatedResult<OrderDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
