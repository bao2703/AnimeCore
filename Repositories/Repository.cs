﻿using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly NeptuneContext Context;

        protected Repository(NeptuneContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public void Attach(TEntity entity)
        {
            DbSet.Attach(entity);
        }

        public int Count()
        {
            return DbSet.Count();
        }
    }
}