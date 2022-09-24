using MediatR;

namespace OnlineShop.Application.Customer.Commands.DeleteCustomer;
public class DeleteCustomerCommand : IRequest
{
    public DeleteCustomerCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
