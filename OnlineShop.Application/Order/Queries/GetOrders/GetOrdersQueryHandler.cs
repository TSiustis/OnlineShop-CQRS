///<summary>
///Handler for GetOrdersQuery.
/// </summary>
namespace OnlineShop.Application.Order.Queries.GetOrders;

using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Helpers;
using OnlineShop.Domain.Interfaces;
using System.Linq.Expressions;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PaginatedResult<OrderDto>>
{
    private readonly IReadRepository<Order> _orderReadRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IReadRepository<Order> orderReadRepository, IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }
    public async Task<PaginatedResult<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var paginationFilter = new PaginationFilter<Order>
        {
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
        };

        var orders = await _orderReadRepository.Get(paginationFilter, cancellationToken);

        return _mapper.Map<PaginatedResult<OrderDto>>(orders);
    }
}

