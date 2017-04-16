using System.Collections.Generic;

namespace Entities.Domain
{
    public class VideoAdsLocation : AdsLocation
    {
        public ICollection<VideoAds> VideoAdses { get; set; }
    }
}