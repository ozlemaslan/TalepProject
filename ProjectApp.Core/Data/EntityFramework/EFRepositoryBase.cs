using ProjectApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Core.Data.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : BaseEntity
    {
        TContext db;
        DbSet<TEntity> entities;
        public EFRepositoryBase()
        {
            db = SingletonContext<TContext>.Context;
            entities = db.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            entities.Add(entity);
            return db.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity,object>>[] includes)
        {
            if (includes!=null)
            {
                return entities.IncludeMultiple(includes).SingleOrDefault(filter);
            }
            else
            {
                return entities.SingleOrDefault(filter);
            }
           
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter != null && includes != null)
            {
                return entities.IncludeMultiple(includes).Where(filter).ToList();
            }
            else if (filter != null)
            {
                return entities.Where(filter).ToList();
            }
            else if (includes != null)
            {
                return entities.IncludeMultiple(includes).ToList();
            }
            else
            {
                return entities.ToList();
            }
        }

        public int Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
