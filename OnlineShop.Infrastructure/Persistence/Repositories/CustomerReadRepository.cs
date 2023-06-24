using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;

namespace OnlineShop.Infrastructure.Persistence.Repositories;

public class CustomerReadRepository : IReadRepository<Customer>
{
    private readonly OnlineShopReadDbContext _dbContext;

    public CustomerReadRepository(OnlineShopReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Customer customer, CancellationToken cancellationToken)
    {
        await _dbContext.Customers.AddAsync(customer, cancellationToken);
    }

    public void Update(Customer customer)
    {
        var customerToUpdate = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

        customerToUpdate.Address = customer.Address;
        customerToUpdate.PhoneNumber = customer.PhoneNumber;
        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.LastName = customer.LastName;
        customerToUpdate.Email = customer.Email;

        _dbContext.Customers.Update(customerToUpdate);
    }

    public async Task<Customer> Get(int id, CancellationToken cancellationToken)
    {
       
 return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);    }

    public async Task<PaginatedResult<Customer>> Get(PaginationFilter<Customer> paginationFilter, CancellationToken cancellationToken)
    {
        var searchQuery = _dbContext.Customers
            .AsNoTracking()
            .Where(paginationFilter.SearchFilter);

        var count = await searchQuery.CountAsync(cancellationToken);

        if (count <= 0)
        {
            return new PaginatedResult<Customer>(
                new List<Customer>(),
                paginationFilter.PageNumber,
                paginationFilter.PageSize,
                count);
        }

        var customers = await searchQuery
            .Skip(paginationFilter.GetSkipCount())
            .Take(paginationFilter.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<Customer>(
            customers,
            paginationFilter.PageNumber,
            paginationFilter.PageSize,
            count);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
