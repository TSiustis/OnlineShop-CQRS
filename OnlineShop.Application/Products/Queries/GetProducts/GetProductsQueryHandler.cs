using AutoMapper;
using MediatR;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Helpers;
using OnlineShop.Domain.Interfaces;
using System.Linq.Expressions;
using OnlineShop.Application.Products.Extensions;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Entities.Customers;

namespace OnlineShop.Application.Products.Queries.GetProducts;
///<summary>
///Handler for GetProductsQuery.
/// </summary>
public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedResult<ProductDto>>
{
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IReadRepository<Product> productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var paginationFilter = new PaginationFilter<Product>
        {
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            SearchFilter = GetProductFilter(request)
        };

        var products = await _productReadRepository.Get(paginationFilter, cancellationToken);

        return new PaginatedResult<ProductDto>(_mapper.Map<List<ProductDto>>(products.Data),
            paginationFilter.PageNumber,
            paginationFilter.PageSize,
            products.TotalRecords);
    }

    private static Expression<Func<Product, bool>> GetProductFilter(GetProductsQuery request)
    {
        return PredicateBuilder.True<Product>()
            .IsNotDeleted()
            .AndContainsTerm(request.SearchQuery);
    }
}
