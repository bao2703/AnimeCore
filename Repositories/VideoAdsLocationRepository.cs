using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IVideoAdsLocationRepository : IBaseRepository<VideoAdsLocation>
    {
    }

    public class VideoAdsLocationRepository : BaseRepository<VideoAdsLocation>, IVideoAdsLocationRepository
    {
        public VideoAdsLocationRepository(NeptuneContext context) : base(context)
        {
        }
    }
}