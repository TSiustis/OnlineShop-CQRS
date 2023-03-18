///<summary>
///Handler for GetOrdersQuery.
/// </summary>
namespace OnlineShop.Application.Order.Queries.GetOrders;

using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IList<OrderDto>>
{
    private readonly IReadRepository<Order> _orderReadRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IReadRepository<Order> orderReadRepository, IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }
    public async Task<IList<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        List<Order> orders;

        orders = await _orderReadRepository.Get(cancellationToken);

        if (orders == null)
        {
            throw new NotFoundException("There are no orders in the database!");
        }

        return _mapper.Map<List<OrderDto>>(orders);
    }
}

