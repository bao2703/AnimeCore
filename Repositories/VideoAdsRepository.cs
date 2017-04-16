using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IVideoAdsRepository : IBaseRepository<VideoAds>
    {
        IEnumerable<VideoAds> GetActiveVideos(string locationName);
    }

    public class VideoAdsRepository : BaseRepository<VideoAds>, IVideoAdsRepository
    {
        public VideoAdsRepository(NeptuneContext context) : base(context)
        {
        }

        public override VideoAds FindById(object id)
        {
            return DbSet.Include(x => x.VideoAdsLocation).SingleOrDefault(x => x.Id == (int) id);
        }

        public override IEnumerable<VideoAds> GetAll()
        {
            return DbSet.Include(x => x.VideoAdsLocation);
        }

        public IEnumerable<VideoAds> GetActiveVideos(string locationName)
        {
            return
                DbSet.Include(x => x.VideoAdsLocation)
                    .Where(x => x.VideoAdsLocation.Name == locationName)
                    .Where(x => x.Status == AdsStatus.Active);
        }
    }
}