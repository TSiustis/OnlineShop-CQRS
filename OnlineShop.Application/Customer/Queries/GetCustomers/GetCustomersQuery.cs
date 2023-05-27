using MediatR;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Common.Pagination;

namespace OnlineShop.Application.Customer.Queries.GetCustomers;
public class GetCustomersQuery : IRequest<PaginatedResult<CustomerDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}

