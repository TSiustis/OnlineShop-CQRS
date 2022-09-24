namespace OnlineShop.Application.Profiles;

using AutoMapper;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Entities.Orders;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderInputDto, Order>();
        CreateMap<OrderItemDto, OrderItem>().ReverseMap();
    }
}
