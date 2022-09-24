namespace OnlineShop.Domain.Events;

using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Products;


public class ProductUpdated : DomainEvent
{
    public ProductUpdated(Product product)
    {
        Product = product;
    }

    public Product Product { get; set; }
}
