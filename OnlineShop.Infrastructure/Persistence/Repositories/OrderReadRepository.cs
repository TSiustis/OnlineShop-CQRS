using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;

namespace OnlineShop.Infrastructure.Persistence.Repositories;
public class OrderReadRepository : IReadRepository<Order>
{
    private readonly OnlineShopReadDbContext _dbContext;

    public OrderReadRepository(OnlineShopReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Order order, CancellationToken cancellationToken)
    {
        await _dbContext.Orders.AddAsync(order, cancellationToken);
    }

    public async Task<Order> Get(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.Include(o => o.Items)
            .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<List<Order>> Get(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.Include(o => o.Items)
            .ToListAsync(cancellationToken);
    }

    public void Update(Order order)
    {
        var orderToUpdate = _dbContext.Orders.FirstOrDefault(o => o.Id == order.Id);

        orderToUpdate.Address = order.Address;
        orderToUpdate.OrderedAt = order.OrderedAt;
        orderToUpdate.ShippedAt = order.ShippedAt;
        orderToUpdate.Status = order.Status;
        orderToUpdate.Items = order.Items;
        orderToUpdate.Amount = order.Amount;
        orderToUpdate.PaymentType = order.PaymentType;

        _dbContext.Orders.Update(orderToUpdate);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
