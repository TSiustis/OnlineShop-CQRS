using MediatR;
using OnlineShop.Application.Products.Dto;

namespace OnlineShop.Application.Products.Commands.AddProduct;
public class AddProductCommand : IRequest
{
    public AddProductCommand(ProductInputDto productInputDto)
    {
        Id = productInputDto.Id;
        Name = productInputDto.Name;
    }

    public int Id { get; }

    public string Name { get; }
}
