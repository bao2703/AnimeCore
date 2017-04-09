namespace Entities.Domain
{
    public class BannerAds : Advertisement
    {
        public string Image { get; set; }

        public BannerAdsLocation BannerAdsLocation { get; set; }
    }
}