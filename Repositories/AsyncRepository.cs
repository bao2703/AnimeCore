using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public abstract class AsyncRepository<TEntity> : BaseRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : Entity
    {
        protected AsyncRepository(NeptuneContext context) : base(context)
        {
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }
    }
}