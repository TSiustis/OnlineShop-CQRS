using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common.Pagination;
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

    public async Task<PaginatedResult<Product>> Get(PaginationFilter<Product> paginationFilter,
        CancellationToken cancellationToken)
    {
        var searchQuery = _dbContext.Products
            .AsNoTracking()
            .Where(paginationFilter.SearchFilter);
        
        var count = await searchQuery.CountAsync(cancellationToken);

        if (count <= 0)
        {
            return new PaginatedResult<Product>(
                new List<Product>(),
                paginationFilter.PageNumber,
                paginationFilter.PageSize,
                count);
        }

        var products = await searchQuery
            .Skip(paginationFilter.GetSkipCount())
            .Take(paginationFilter.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<Product>(
            products,
            paginationFilter.PageNumber,
            paginationFilter.PageSize,
            count);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
