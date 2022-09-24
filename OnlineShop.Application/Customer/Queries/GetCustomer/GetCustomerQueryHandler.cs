namespace OnlineShop.Application.Customer.Queries.GetCustomer;

using AutoMapper;
using MediatR;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Interfaces;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    private readonly IReadRepository<Customer> _customerReadRepository;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IReadRepository<Customer> customerReadRepository, IMapper mapper)
    {
        _customerReadRepository = customerReadRepository;
        _mapper = mapper;
    }
    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        Customer customer = await _customerReadRepository.Get(request.Id, cancellationToken);

        if (customer == null)
        {
            throw new NotFoundException($"Entity with id {request.Id} was not found!");
        }

        return _mapper.Map<CustomerDto>(customer);
    }
}
