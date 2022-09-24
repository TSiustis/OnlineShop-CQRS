using MediatR;
using OnlineShop.Application.Customer.Dto;

namespace OnlineShop.Application.Customer.Queries.GetCustomers;
public class GetCustomersQuery : IRequest<List<CustomerDto>>
{

}

