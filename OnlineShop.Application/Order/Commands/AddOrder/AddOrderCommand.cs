///<summary>
///Command for adding an order.
/// </summary>
using MediatR;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Application.Order.Commands.AddOrder;
public class AddOrderCommand : IRequest
{
    public AddOrderCommand(OrderInputDto orderInputDto)
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
