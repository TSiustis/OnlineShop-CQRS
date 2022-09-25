namespace OnlineShop.Domain.Interfaces;

using OnlineShop.Domain.Common;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    Task Add(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    Task<TEntity> Get(int id, CancellationToken cancellationToken);

    Task<List<TEntity>> Get(CancellationToken cancellationToken);

    Task SaveChanges(CancellationToken cancellationToken);
}
