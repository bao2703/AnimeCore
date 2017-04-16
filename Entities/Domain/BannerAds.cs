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
        public BannerAds()
        {
            Height = "100%";
            Width = "100%";
        }

        [Display(Name = "Location type")]
        public LocationType LocationType { get; set; }

        public string Height { get; set; }

        public string Width { get; set; }

        public int? BannerAdsLocationId { get; set; }

        public BannerAdsLocation BannerAdsLocation { get; set; }
    }
}