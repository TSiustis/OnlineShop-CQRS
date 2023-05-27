///<summary>
///Query for retrieving all product.
/// </summary>
using MediatR;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Application.Products.Queries.GetProducts;
public class GetProductsQuery : IRequest<PaginatedResult<ProductDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
