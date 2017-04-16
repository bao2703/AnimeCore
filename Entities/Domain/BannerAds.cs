using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum LocationType
    {
        Home,
        Child,
        Both
    }

    public class BannerAds : Advertisement
    {
        [Display(Name = "Location type")]
        public LocationType LocationType { get; set; }

        public int? BannerAdsLocationId { get; set; }

        public BannerAdsLocation BannerAdsLocation { get; set; }
    }
}