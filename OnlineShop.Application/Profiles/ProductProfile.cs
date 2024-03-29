﻿using AutoMapper;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
        CreateMap<PaginatedResult<Product>, PaginatedResult<ProductDto>>()
            .ReverseMap();
        CreateMap<ProductInputDto, Product>();
    }
}
