using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IBannerAdsRepository : IBaseRepository<BannerAds>
    {
        IEnumerable<BannerAds> GetActiveBanners(string locationName);
        IEnumerable<BannerAds> GetActiveBanners(string locationName, BannerType bannerType);
    }

    public class BannerAdsRepository : BaseRepository<BannerAds>, IBannerAdsRepository
    {
        public BannerAdsRepository(NeptuneContext context) : base(context)
        {
        }

        public override BannerAds FindById(object id)
        {
            return DbSet.Include(x => x.AdsLocation).SingleOrDefault(x => x.Id == (int) id);
        }

        public override IEnumerable<BannerAds> GetAll()
        {
            return DbSet.Include(x => x.AdsLocation).Include(x => x.Customer);
        }

        public IEnumerable<BannerAds> GetActiveBanners(string locationName)
        {
            return
                DbSet.Include(x => x.AdsLocation)
                    .Where(x => x.AdsLocation.Name == locationName)
                    .Where(x => x.Status == AdsStatus.Active);
        }

        public IEnumerable<BannerAds> GetActiveBanners(string locationName, BannerType bannerType)
        {
            return
                GetActiveBanners(locationName)
                    .Where(x => x.BannerType == bannerType || x.BannerType == BannerType.HomeChild);
        }
    }
}