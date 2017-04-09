using System.Collections.Generic;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IVideoAdsRepository : IBaseRepository<VideoAds>
    {
    }

    public class VideoAdsRepository : BaseRepository<VideoAds>, IVideoAdsRepository
    {
        public VideoAdsRepository(NeptuneContext context) : base(context)
        {
        }

        public override IEnumerable<VideoAds> GetAll()
        {
            return DbSet.Include(x => x.AdsLocation);
        }
    }
}