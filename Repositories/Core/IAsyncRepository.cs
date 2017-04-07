using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Domain;

namespace Repositories.Core
{
    public interface IAsyncRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}