///<summary>
///Command for adding a product.
/// </summary>
using MediatR;
using OnlineShop.Application.Products.Dto;

namespace OnlineShop.Application.Products.Commands.AddProduct;
public class AddProductCommand : IRequest
{
    public AddProductCommand(ProductInputDto productInputDto)
    {
        Id = productInputDto.Id;
        Name = productInputDto.Name;
        Description= productInputDto.Description;
        Category= productInputDto.Category;
        Price = productInputDto.Price;
    }

    public int Id { get; }

    public string Name { get; }
    
    public string Description { get; }

    public string Category { get; }

    public decimal Price { get; }

    public int Stock { get; }
}
