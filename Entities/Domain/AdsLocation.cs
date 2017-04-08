using System.Collections.Generic;

namespace Entities.Domain
{
    public class AdsLocation : Entity
    {
        public string Name { get; set; }

        public string Desciption { get; set; }

        public AdsType AdsType { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}