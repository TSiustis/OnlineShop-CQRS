using OnlineShop.Domain.Common;
using OnlineShop.Domain.Common.Pagination;

namespace OnlineShop.Domain.Interfaces;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    Task Add(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    Task<TEntity> Get(int id, CancellationToken cancellationToken);

    Task<PaginatedResult<TEntity>> Get(PaginationFilter<TEntity> paginationFilter,
        CancellationToken cancellationToken);

    Task SaveChanges(CancellationToken cancellationToken);
}
