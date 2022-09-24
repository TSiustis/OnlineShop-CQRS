namespace OnlineShop.Application.Order.Queries.GetOrder;

using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;
public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
    private readonly IReadRepository<Order> _orderReadRepository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IReadRepository<Order> orderReadRepository, IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {

        Order order = await _orderReadRepository.Get(request.Id, cancellationToken);

        if (order == null)
        {
            throw new NotFoundException($"Entity with id {request.Id} was not found!");
        }

        return _mapper.Map<OrderDto>(order);
    }
}

