using System.Collections.Generic;

namespace Entities.Domain
{
    public enum LocationType
    {
        Home,
        Child,
        Both
    }

    public class BannerAdsLocation : AdsLocation
    {
        public LocationType LocationType { get; set; }

        public ICollection<BannerAds> BannerAdses { get; set; }
    }
}