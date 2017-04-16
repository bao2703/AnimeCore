namespace Entities.Domain
{
    public class VideoAds : Advertisement
    {
        public int? VideoAdsLocationId { get; set; }

        public VideoAdsLocation VideoAdsLocation { get; set; }
    }
}