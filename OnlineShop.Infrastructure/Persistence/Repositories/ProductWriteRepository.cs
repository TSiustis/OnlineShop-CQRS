using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.DatabaseContext;

namespace OnlineShop.Infrastructure.Persistence.Repositories;
public class ProductWriteRepository : IWriteRepository<Product>
{
    private readonly OnlineShopWriteDbContext _dbContext;

    public ProductWriteRepository(OnlineShopWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        var productToUpdate = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        productToUpdate.Name = product.Name;

        _dbContext.Products.Update(productToUpdate);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Delete(int id)
    {
        var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

        if(product == null)
        {
            throw new InvalidOperationException($"Customer with id {id} does not exist!");
        }

        _dbContext.Products.Remove(product);
    }
    
}
