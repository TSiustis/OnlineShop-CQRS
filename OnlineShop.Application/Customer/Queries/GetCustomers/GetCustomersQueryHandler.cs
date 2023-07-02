namespace OnlineShop.Application.Customer.Queries.GetCustomers;

using OnlineShop.Domain.Common.Pagination;
using AutoMapper;
using MediatR;
using Dto;
using Domain.Entities.Customers;
using Domain.Interfaces;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, PaginatedResult<CustomerDto>>
{
    private readonly IReadRepository<Customer> _customerReadRepository;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(IReadRepository<Customer> customerReadRepository, IMapper mapper)
    {
        _customerReadRepository = customerReadRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var paginationFilter = new PaginationFilter<Customer>
        {
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
        };

        var customers = await _customerReadRepository.Get(paginationFilter, cancellationToken);

        return new PaginatedResult<CustomerDto>(_mapper.Map<List<CustomerDto>>(customers.Data),
            paginationFilter.PageNumber, 
            paginationFilter.PageSize,
            customers.TotalRecords);
    }
}
