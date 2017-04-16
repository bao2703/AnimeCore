namespace Entities.Domain
{
    public class BannerAds : Advertisement
    {
        public int? BannerAdsLocationId { get; set; }

        public BannerAdsLocation BannerAdsLocation { get; set; }
    }
}