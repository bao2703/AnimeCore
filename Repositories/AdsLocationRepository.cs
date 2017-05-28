using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace Repositories
{
    public interface IAdsLocationRepository : IBaseRepository<AdsLocation>
    {
        IEnumerable<AdsLocation> GetAll(LocationType locationType);
    }

    public class AdsLocationRepository : BaseRepository<AdsLocation>, IAdsLocationRepository
    {
        public AdsLocationRepository(NeptuneContext context) : base(context)
        {
        }

        public override IEnumerable<AdsLocation> GetAll()
        {
            return DbSet.Include(x => x.Advertisements);
        }

        public IEnumerable<AdsLocation> GetAll(LocationType locationType)
        {
            return GetAll().Where(x => x.LocationType == locationType);
        }
    }
}