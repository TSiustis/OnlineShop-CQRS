namespace OnlineShop.Domain.Events;

using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Products;

public class ProductCreated : DomainEvent
{
    public ProductCreated(Product product)
    {
        Product = product;
    }

    public Product Product { get; set; }
}
