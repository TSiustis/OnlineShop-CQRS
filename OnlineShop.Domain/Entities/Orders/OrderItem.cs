using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Entities.Orders;
public class OrderItem : Entity
{
    public ItemOrdered Item { get; }

    public int Units { get; }
    
    public decimal Price { get; }

    public  OrderItem()
    {

    }

    public OrderItem(ItemOrdered item, int units, decimal price)
    {
        Item = item;
        Units = units;
        Price = price;
    }

    
}
