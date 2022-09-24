using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Customers;
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

    public void Update(Customer customer, CancellationToken cancellationToken)
    {
        _dbContext.Customers.Update(customer);
    }

    public async Task<Customer> Get(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<List<Customer>> Get(CancellationToken cancellationToken)
    {
        return await _dbContext.Customers.ToListAsync(cancellationToken);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
