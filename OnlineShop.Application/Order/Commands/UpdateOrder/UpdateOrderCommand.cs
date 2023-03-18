///<summary>
///Command for updating an order.
/// </summary>

namespace OnlineShop.Application.Order.Commands.UpdateOrder;

using MediatR;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Orders;

public class UpdateOrderCommand : IRequest
{
    public UpdateOrderCommand(OrderInputDto orderInputDto)
    {
        Id = orderInputDto.Id;
        Items = orderInputDto.Items;
        ShippedAt = orderInputDto.ShippedAt;
        Address = orderInputDto.Address;
        Status = orderInputDto.Status;
        PaymentType = orderInputDto.PaymentType;
        Amount = orderInputDto.Amount;
    }

    public int Id { get; set; }

    public ICollection<OrderItemDto> Items { get; }

    public DateTimeOffset ShippedAt { get; }

    public Address Address { get; }

    public OrderStatus Status { get; }

    public PaymentType PaymentType { get; }

    public decimal Amount { get; }
}
