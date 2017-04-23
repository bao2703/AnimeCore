using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IPermissionRepository : IBaseRepository<Permission>
    {
    }

    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(NeptuneContext context) : base(context)
        {
        }
    }
}