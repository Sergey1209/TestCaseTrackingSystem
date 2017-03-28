using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementation
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, bool>>[] includeExpressions)
        {
            var query = Context.Set<TEntity>();

            foreach (var includeExpression in includeExpressions)
            {
                query.Include(includeExpression);
            }

            return query.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveById(int id)
        {
            Context.Set<TEntity>().Remove(Context.Set<TEntity>().Find(id));
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public bool HasAny()
        {
            return Context.Set<TEntity>().Any();
        }
    }
}
