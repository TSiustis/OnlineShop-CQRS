using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Customer.Dto;
public class CustomerDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Address Address { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}
