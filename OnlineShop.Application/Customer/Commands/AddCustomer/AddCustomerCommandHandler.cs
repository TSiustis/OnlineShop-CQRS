using MediatR;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Events;
using AutoMapper;
using OnlineShop.Domain.Common;

namespace OnlineShop.Application.Customer.Commands.AddCustomer;


public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand>
{
    private readonly IWriteRepository<Domain.Entities.Customers.Customer> _customerWriteRepository;

    public AddCustomerCommandHandler(IWriteRepository<Domain.Entities.Customers.Customer> customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customers.Customer(request.FirstName, request.LastName, request.Address, request.Email, request.PhoneNumber);

        await _customerWriteRepository.Add(customer, cancellationToken);

        customer.DomainEvents.Add(new CustomerCreated(customer));

        await _customerWriteRepository.SaveChanges(cancellationToken);
        
        return Unit.Value;
    }
}
