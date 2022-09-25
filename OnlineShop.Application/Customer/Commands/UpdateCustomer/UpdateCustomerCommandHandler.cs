using MediatR;
using OnlineShop.Domain.Events;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly IWriteRepository<Domain.Entities.Customers.Customer> _customerWriteRepository;

    public UpdateCustomerCommandHandler(IWriteRepository<Domain.Entities.Customers.Customer> customerWriteRepository)
    {
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Domain.Entities.Customers.Customer(request.Id, request.FirstName, request.LastName, request.Address, request.Email, request.PhoneNumber);

        _customerWriteRepository.Update(customer);

        customer.DomainEvents.Add(new CustomerUpdated(customer));

        await _customerWriteRepository.SaveChanges(cancellationToken);

        return await Unit.Task;
    }
}
