namespace OnlineShop.Application.Profiles;

using AutoMapper;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Customers;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName}  {src.LastName}"));
        CreateMap<CustomerInputDto, Customer>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}
