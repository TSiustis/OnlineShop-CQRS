using AutoMapper;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductInputDto, Product>();
    }
}
