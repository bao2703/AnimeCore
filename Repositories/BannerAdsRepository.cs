using System;
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
        IEnumerable<BannerAds> GetAvailableBannerAdvertisements(string locationName);
    }

    public class BannerAdsRepository : BaseRepository<BannerAds>, IBannerAdsRepository
    {
        public BannerAdsRepository(NeptuneContext context) : base(context)
        {
        }

        public override BannerAds FindById(object id)
        {
            return DbSet.Include(x => x.BannerAdsLocation).SingleOrDefault(x => x.Id == (int) id);
        }

        public override IEnumerable<BannerAds> GetAll()
        {
            return DbSet.Include(x => x.BannerAdsLocation);
        }

        public IEnumerable<BannerAds> GetAvailableBannerAdvertisements(string locationName)
        {
            return
                DbSet.Include(x => x.BannerAdsLocation)
                    .Where(x => x.BannerAdsLocation.Name == locationName)
                    .Where(x => x.StartDate <= DateTime.Now)
                    .Where(x => x.EndDate >= DateTime.Today);
        }
    }
}