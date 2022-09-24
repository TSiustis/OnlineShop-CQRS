using OnlineShop.Domain.Common;
using OnlineShop.Domain.Common.Interfaces;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Entities.Orders;
public class Order : Entity, IAggregateRoot, IHasDomainEvent
{
    private readonly List<OrderItem> _items;

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public DateTimeOffset OrderedAt { get; private set; }

    public DateTimeOffset ShippedAt { get; private set; }

    public Address Address { get; private set; }

    public OrderStatus Status { get; private set; }

    public PaymentType PaymentType { get; private set; }

    public decimal Amount { get; private set; }

    protected Order()
    {
        _items = new List<OrderItem>();
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

    public void AddOrderItem(Product product, decimal price, int units = 1)
    {
        _items.Add(new OrderItem(product, units, price));
    }
}
