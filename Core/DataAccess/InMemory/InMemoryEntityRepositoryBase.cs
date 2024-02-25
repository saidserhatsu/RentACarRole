using Core.Entities;
using System.Collections;

namespace Core.DataAccess.InMemory;

public abstract class InMemoryEntityRepositoryBase<TEntity, TEntityId>
    : IEntityRepository<TEntity, TEntityId>
    where TEntity : class, IEntity<TEntityId>, new()
{
    protected readonly HashSet<TEntity> _entities = new();

    protected abstract TEntityId generateId();

    public TEntity Add(TEntity entity)
    {
        entity.Id = generateId();
        entity.CreatedAt = DateTime.UtcNow;
        _entities.Add(entity);
        return entity;
    }

    public TEntity Delete(TEntity entity, bool isSoftDelete = true)
    {
        if (!isSoftDelete)
        {
            _entities.Remove(entity);
        }
        entity.DeletedAt = DateTime.UtcNow;
        return entity;

    }

    public TEntity? Get(Func<TEntity, bool>? predicate)
    {
        TEntity? entity = _entities.FirstOrDefault(predicate);
        return entity;
    }

    public IList<TEntity> GetList(Func<TEntity, bool>? predicate)
    {
        IEnumerable<TEntity> query = _entities;
        if(predicate != null)
        {
            query = query.Where(predicate);
        }
        return query.ToArray();
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        return entity;
    }
}
