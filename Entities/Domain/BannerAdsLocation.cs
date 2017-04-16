using System.Collections.Generic;

namespace Entities.Domain
{
    public class BannerAdsLocation : AdsLocation
    {
        public ICollection<BannerAds> BannerAdses { get; set; }
    }
}