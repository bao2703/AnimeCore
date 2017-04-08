using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IAdsLocationRepository : IBaseRepository<AdsLocation>
    {
    }

    public class AdsLocationRepository : BaseRepository<AdsLocation>, IAdsLocationRepository
    {
        public AdsLocationRepository(NeptuneContext context) : base(context)
        {
        }
    }
}