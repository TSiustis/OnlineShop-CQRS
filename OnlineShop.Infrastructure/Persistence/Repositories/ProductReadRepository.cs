using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;

namespace OnlineShop.Infrastructure.Persistence.Repositories;

public class ProductReadRepository : IReadRepository<Product>
{
    private readonly OnlineShopReadDbContext _dbContext;

    public ProductReadRepository(OnlineShopReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
    }

    public void Update(Product product)
    {
        var productToUpdate = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        productToUpdate.Name = product.Name;

        _dbContext.Products.Update(productToUpdate);
    }

    public async Task<Product> Get(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Product>> Get(CancellationToken cancellationToken)
    {
        return await _dbContext.Products.ToListAsync(cancellationToken);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
