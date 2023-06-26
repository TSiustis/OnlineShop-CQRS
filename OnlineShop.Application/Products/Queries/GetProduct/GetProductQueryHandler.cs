///<summary>
///Handler for GetProductQuery.
/// </summary>
using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Products.Queries.GetProduct;
public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IReadRepository<Product> productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productReadRepository.Get(request.Id, cancellationToken);

        if (product == null)
        {
            throw new NotFoundException($"Entity with id {request.Id} was not found!");
        }

        return _mapper.Map<ProductDto>(product);
    }
}
