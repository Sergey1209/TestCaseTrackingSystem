﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, bool>>[] includeExpressions);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveById(int id);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        bool HasAny();
    }
}
