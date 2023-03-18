///<summary>
///Command for deleting a product.
/// </summary>
using MediatR;

namespace OnlineShop.Application.Products.Commands.DeleteProduct;
public class DeleteProductCommand : IRequest
{
    public DeleteProductCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
