///<summary>
///Query for retrieving all product.
/// </summary>
using MediatR;
using OnlineShop.Application.Products.Dto;

namespace OnlineShop.Application.Products.Queries.GetProducts;
public class GetProductsQuery : IRequest<IList<ProductDto>>
{

}
