using OnlineShop.Domain.Common;
using OnlineShop.Domain.Common.Interfaces;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Entities.Orders;
public class Order : Entity, IAggregateRoot, IHasDomainEvent
{
    public IList<OrderItem> Items { get; set; }

    public DateTimeOffset OrderedAt { get; set; }

    public DateTimeOffset ShippedAt { get; set; }

    public Address Address { get; set; }

    public OrderStatus Status { get; set; }

    public PaymentType PaymentType { get; set; }

    public decimal Amount { get; set; }

    protected Order()
    {
        Items = new List<OrderItem>();
    }

    public Order(DateTimeOffset shippedAt, Address address, PaymentType paymentType, OrderStatus status, decimal amount) : this()
    {
        OrderedAt = DateTime.UtcNow;
        ShippedAt = shippedAt;
        Address = address;
        PaymentType = paymentType;
        Status = status;
        Amount = amount;
    }

    public Order(int id, DateTimeOffset shippedAt, Address address, PaymentType paymentType, OrderStatus status, decimal amount)
    {
        Id = id;
        ShippedAt = shippedAt;
        Address = address;
        PaymentType = paymentType;
        Status = status;
        Amount = amount;
    }

    public void AddOrderItem(Product product, decimal price, int units = 1)
    {
        Items.Add(new OrderItem(product, units, price));
    }
}
