using System.Collections.Generic;
using Entities.Domain;

namespace Repositories.Core
{
    public interface IRepository<in TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Attach(TEntity entity);

        int Count();
    }
}