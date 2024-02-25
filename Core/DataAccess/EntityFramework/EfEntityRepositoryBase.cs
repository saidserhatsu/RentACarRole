using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TEntityId,TContext> : IEntityRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TContext : DbContext
    {
        private readonly TContext _context;
        public EfEntityRepositoryBase(TContext context)
        {
            this._context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity, bool isSoftDelete = true)
        {
            entity.DeletedAt= DateTime.UtcNow;
            if (!isSoftDelete)
            {
                _context.Remove(entity);
            }
            return entity;

        }

        public TEntity? Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IList<TEntity> GetList(Func<TEntity, bool>? predicate)
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            if(predicate != null)
            {
                entities = entities.Where(predicate).AsQueryable();
            }
            return entities.ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdateAt= DateTime.UtcNow;   
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
