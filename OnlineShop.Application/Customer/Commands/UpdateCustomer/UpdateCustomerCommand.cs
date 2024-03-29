﻿using MediatR;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Customer.Commands.UpdateCustomer;
public class UpdateCustomerCommand : IRequest
{
    public UpdateCustomerCommand(CustomerInputDto customerInput)
    {
        Id = customerInput.Id;
        FirstName = customerInput.FirstName;
        LastName = customerInput.LastName;
        Address = customerInput.Address;
        Email = customerInput.Email;
        PhoneNumber = customerInput.PhoneNumber;
    }

    public int Id { get; }
    public string FirstName { get; }

    public string LastName { get; }

    public Address Address { get; }

    public string Email { get; }

    public string PhoneNumber { get; }
}
