using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum LocationType
    {
        Home,
        Child,
        [Display(Name = "Home & Child")] HomeChild
    }

    public class BannerAds : Advertisement
    {
        [Display(Name = "Location type")]
        public LocationType LocationType { get; set; }

        public string Height { get; set; }

        public string Width { get; set; }

        public int? BannerAdsLocationId { get; set; }

        public BannerAdsLocation BannerAdsLocation { get; set; }
    }
}