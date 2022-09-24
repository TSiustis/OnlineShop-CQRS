namespace OnlineShop.Application.Customer.Queries.GetCustomers;

using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Interfaces;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly IReadRepository<Customer> _customerReadRepository;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(IReadRepository<Customer> customerReadRepository, IMapper mapper)
    {
        _customerReadRepository = customerReadRepository;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        List<Customer> customers;

        customers = await _customerReadRepository.Get(cancellationToken);

        if (customers == null)
        {
            throw new NotFoundException("There are no customers in the database!");
        }

        return _mapper.Map<List<CustomerDto>>(customers);
    }
}
