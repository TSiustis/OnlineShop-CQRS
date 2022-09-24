using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Domain.Entities.Orders;
public class OrderItem : Entity
{
    public Product Product { get; }

    public int NumberOfProducts { get; }
    
    public decimal ProductPrice { get; }

    public  OrderItem()
    {

    }

    public OrderItem(Product product, int numberOfProducts, decimal productPrice)
    {
        Product = product;
        NumberOfProducts = numberOfProducts;
        ProductPrice = productPrice;
    }

    
}
