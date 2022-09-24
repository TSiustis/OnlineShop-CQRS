using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;

namespace OnlineShop.Infrastructure.Persistence.Repositories;
public class CustomerWriteRepository : IWriteRepository<Customer>
{
    private readonly OnlineShopWriteDbContext _dbContext;

    public CustomerWriteRepository(OnlineShopWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Customer customer, CancellationToken cancellationToken)
    {
        await _dbContext.Customers.AddAsync(customer, cancellationToken);
    }

    public void Update(Customer customer)
    {
       _dbContext.Customers.Update(customer);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Delete(int id)
    {
        var customer = _dbContext.Customers.Find(id);

        _dbContext.Customers.Remove(customer);
    }
}
