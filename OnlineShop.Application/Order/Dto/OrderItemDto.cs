using OnlineShop.Application.Products.Dto;

namespace OnlineShop.Application.Order.Dto;

public class OrderItemDto
{
    public OrderItemDto(ProductDto product, int numberOfProducts, decimal productPrice)
    {
        Product = product;
        NumberOfProducts = numberOfProducts;    
        ProductPrice = productPrice;
    }

    public ProductDto Product { get; }

    public int NumberOfProducts { get; }

    public decimal ProductPrice { get; }
}
