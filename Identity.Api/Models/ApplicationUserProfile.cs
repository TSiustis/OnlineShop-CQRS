using AutoMapper;
using OnlineShop.Domain.Entities.Customers;

namespace Identity.Api.Models;


public class ApplicationUserProfile : Profile
{
    public ApplicationUserProfile()
    {
        CreateMap<ApplicationUser, Customer>()
            .ForMember(model => model.Id, opt => opt.MapFrom(data => data.Id))
            .ForMember(model => model.FirstName, opt => opt.MapFrom(data => data.FirstName))
            .ForMember(model => model.LastName, opt => opt.MapFrom(data => data.LastName))
            .ForMember(model => model.PhoneNumber, opt => opt.MapFrom(data => data.PhoneNumber))
            .ForMember(model => model.Email, opt => opt.MapFrom(data => data.Email))
            .ReverseMap();
    }
}
