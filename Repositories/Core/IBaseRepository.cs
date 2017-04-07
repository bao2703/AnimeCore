using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Domain;

namespace Repositories.Core
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        TEntity FindById(object id);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector);

        IEnumerable<TEntity> OrderByDescending<TKey>(Expression<Func<TEntity, TKey>> keySelector);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> ToList();
    }
}