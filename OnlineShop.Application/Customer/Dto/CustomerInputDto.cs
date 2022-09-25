using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Customer.Dto;
public class CustomerInputDto 
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Address Address { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}
