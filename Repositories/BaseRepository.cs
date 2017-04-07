﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public abstract class BaseRepository<TEntity> : Repository<TEntity>, IBaseRepository<TEntity> where TEntity : Entity
    {
        protected BaseRepository(NeptuneContext context) : base(context)
        {
        }

        public TEntity FindById(object id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public IEnumerable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return DbSet.OrderBy(keySelector);
        }

        public IEnumerable<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return DbSet.OrderByDescending(keySelector);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public List<TEntity> ToList()
        {
            return DbSet.ToList();
        }
    }
}