using MediatR;
using OnlineShop.Application.Customer.Dto;

namespace OnlineShop.Application.Customer.Queries.GetCustomer;
public class GetCustomerQuery : IRequest<CustomerDto>
{
    public GetCustomerQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
