///<summary>
///Query for retrieving a product.
/// </summary>
using MediatR;
using OnlineShop.Application.Products.Dto;

namespace OnlineShop.Application.Products.Queries.GetProduct;
public class GetProductQuery : IRequest<ProductDto>
{
    public GetProductQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
