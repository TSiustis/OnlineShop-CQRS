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
        var customerToUpdate = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

        customerToUpdate.Address = customer.Address;
        customerToUpdate.PhoneNumber = customer.PhoneNumber;
        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.LastName = customer.LastName;
        customerToUpdate.Email = customer.Email;

       _dbContext.Customers.Update(customerToUpdate);
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
