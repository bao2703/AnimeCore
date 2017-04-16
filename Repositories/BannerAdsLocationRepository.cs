using Entities;
using Entities.Domain;
using Repositories.Core;

namespace Repositories
{
    public interface IBannerAdsLocationRepository : IBaseRepository<BannerAdsLocation>
    {
    }

    public class BannerAdsLocationRepository : BaseRepository<BannerAdsLocation>, IBannerAdsLocationRepository
    {
        public BannerAdsLocationRepository(NeptuneContext context) : base(context)
        {
        }
    }
}