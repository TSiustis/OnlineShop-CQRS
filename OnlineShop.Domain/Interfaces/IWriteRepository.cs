using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Interfaces;

public interface IWriteRepository<in TEntity> where TEntity : Entity
{
    Task Add(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    Task SaveChanges(CancellationToken cancellationToken);

    void Delete(int id);
}
