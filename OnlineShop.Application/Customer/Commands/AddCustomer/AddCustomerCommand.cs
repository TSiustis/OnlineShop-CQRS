using MediatR;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Customer.Commands.AddCustomer;

public class AddCustomerCommand : IRequest
{
    public AddCustomerCommand(CustomerInputDto customerInput)
    {
        FirstName = customerInput.FirstName;
        LastName = customerInput.LastName;
        Address = customerInput.Address;
        Email = customerInput.Email;
        PhoneNumber = customerInput.PhoneNumber;
    }

    public string FirstName { get; }

    public string LastName { get; }

    public Address Address { get; }

    public string Email { get; }

    public string PhoneNumber { get; }
}
