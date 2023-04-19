///<summary>
///Command for updating a product.
/// </summary>
using MediatR;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Application.Products.Commands.UpdateProduct;
public class UpdateProductCommand : IRequest
{
    public UpdateProductCommand(ProductInputDto productInputDto)
    {
        Id = productInputDto.Id;
        Name = productInputDto.Name;
        Description = productInputDto.Description;
        Category= productInputDto.Category;
        Price = productInputDto.Price;
        Stock= productInputDto.Stock;
        ImageUri = productInputDto.ImageUri;
    }

    public int Id { get; }

    public string Name { get; }

    public string Description { get; }
    
    public Category Category { get; }

    public decimal Price { get; }

    public int Stock { get; }

    public string ImageUri { get; }
}
