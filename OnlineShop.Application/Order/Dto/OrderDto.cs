namespace OnlineShop.Application.Order.Dto
{
    using OnlineShop.Domain.Common;
    using OnlineShop.Domain.Entities.Orders;

    public class OrderDto
    {
        public IReadOnlyCollection<OrderItem> Items { get; set; }

        public DateTimeOffset OrderedAt { get; set; }

        public DateTimeOffset ShippedAt { get; set; }

        public Address Address { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal Amount { get; set; }
    }
}
