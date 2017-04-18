using System.Collections.Generic;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
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

        public override IEnumerable<BannerAdsLocation> GetAll()
        {
            return DbSet.Include(x => x.BannerAdses);
        }
    }
}