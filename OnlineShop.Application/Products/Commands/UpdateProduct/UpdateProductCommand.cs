///<summary>
///Command for updating a product.
/// </summary>
using MediatR;
using OnlineShop.Application.Products.Dto;

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

    }

    public int Id { get; }

    public string Name { get; }

    public string Description { get; }
    
    public string Category { get; }

    public decimal Price { get; }

    public int Stock { get; }
}
