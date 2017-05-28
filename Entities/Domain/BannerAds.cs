using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum BannerType
    {
        Home,
        Child,
        [Display(Name = "Home & Child")] HomeChild
    }

    public class BannerAds : Advertisement
    {
        [Display(Name = "Location type")]
        public BannerType BannerType { get; set; }

        public string Height { get; set; }

        public string Width { get; set; }

        public int? AdsLocationId { get; set; }

        public AdsLocation AdsLocation { get; set; }
    }
}