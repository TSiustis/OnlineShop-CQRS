using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common.Pagination;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;
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

    public async Task<PaginatedResult<Order>> Get(PaginationFilter<Order> paginationFilter, CancellationToken cancellationToken)
    {
        var searchQuery = _dbContext.Orders
            .AsNoTracking()
            .Where(paginationFilter.SearchFilter);

        var count = await searchQuery.CountAsync(cancellationToken);

        if (count <= 0)
        {
            return new PaginatedResult<Order>(
                new List<Order>(),
                paginationFilter.PageNumber,
                paginationFilter.PageSize,
                count);
        }

        var orders = await searchQuery
            .Skip(paginationFilter.GetSkipCount())
            .Take(paginationFilter.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<Order>(
            orders,
            paginationFilter.PageNumber,
            paginationFilter.PageSize,
            count);
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
