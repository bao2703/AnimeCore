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
    }
}