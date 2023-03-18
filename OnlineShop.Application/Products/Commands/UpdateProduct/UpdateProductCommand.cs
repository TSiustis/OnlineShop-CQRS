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
    }

    public int Id { get; }

    public string Name { get; }
}
