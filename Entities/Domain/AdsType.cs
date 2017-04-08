using System.Collections.Generic;

namespace Entities.Domain
{
    public class AdsType : Entity
    {
        public long Price { get; set; }

        public string Description { get; set; }

        public ICollection<AdsLocation> AdsLocations { get; set; }
    }
}