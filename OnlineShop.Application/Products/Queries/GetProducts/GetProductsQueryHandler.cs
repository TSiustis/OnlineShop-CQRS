///<summary>
///Handler for GetProductsQuery.
/// </summary>
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Products.Queries.GetProducts;
public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IList<ProductDto>>
{
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IMapper _mapper;
    public GetProductsQueryHandler(IReadRepository<Product> productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }
    public async Task<IList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product> products;

        products = await _productReadRepository.Get(cancellationToken);

        if (products == null)
        {
            throw new NotFoundException("There are no products in the database!");
        }

        return _mapper.Map<List<ProductDto>>(products);
    }
}
