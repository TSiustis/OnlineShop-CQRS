using OnlineShop.Application.Order.Dto;

namespace OnlineShop.Application.Order.Commands.UpdateOrder;

using MediatR;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Orders;

public class UpdateOrderCommand : IRequest
{
    public UpdateOrderCommand(OrderInputDto orderInputDto)
    {
        Items = orderInputDto.Items;
        ShippedAt = orderInputDto.ShippedAt;
        Address = orderInputDto.Address;
        Status = orderInputDto.Status;
        PaymentType = orderInputDto.PaymentType;
        Amount = orderInputDto.Amount;
    }

    public ICollection<OrderItemDto> Items { get; }

    public DateTimeOffset ShippedAt { get; }

    public Address Address { get; }

    public OrderStatus Status { get; }

    public PaymentType PaymentType { get; }

    public decimal Amount { get; }
}
