using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IAdvertisementRepository : IBaseRepository<Advertisement>
    {
    }

    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(NeptuneContext context) : base(context)
        {
        }

        public override Advertisement FindById(object id)
        {
            return DbSet.Include(x => x.AdsLocation).SingleOrDefault(x => x.Id == (int) id);
        }

        public override IEnumerable<Advertisement> GetAll()
        {
            return DbSet.Include(x => x.AdsLocation);
        }
    }
}