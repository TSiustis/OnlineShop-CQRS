﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Common.CustomExceptions;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;

namespace OnlineShop.Infrastructure.Persistence.Repositories;
public class OrderWriteRepository : IWriteRepository<Order>
{
    private readonly OnlineShopWriteDbContext _dbContext;

    public OrderWriteRepository(OnlineShopWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Order order, CancellationToken cancellationToken)
    {
         await _dbContext.Orders.AddAsync(order, cancellationToken);
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

    public void Delete(int id)
    {
        var order = _dbContext.Orders
            .Include(o => o.Items)  
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            throw new NotFoundException($"Order with id {order.Id} does not exist!");
        }

        _dbContext.Remove(order);
    }
}
