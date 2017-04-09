using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IVideoAdsLocationRepository : IBaseRepository<AdsLocation>
    {
    }

    public class VideoAdsLocationRepository : BaseRepository<AdsLocation>, IVideoAdsLocationRepository
    {
        public VideoAdsLocationRepository(NeptuneContext context) : base(context)
        {
        }
    }
}