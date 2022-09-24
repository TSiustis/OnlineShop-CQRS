using MediatR;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Application.Customer.Commands.DeleteCustomer;
public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly IWriteRepository<Domain.Entities.Customers.Customer> _customerRepository;

    public DeleteCustomerCommandHandler(IWriteRepository<Domain.Entities.Customers.Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        _customerRepository.Delete(request.Id);

        await _customerRepository.SaveChanges(cancellationToken);

        return await Unit.Task;
    }
}
