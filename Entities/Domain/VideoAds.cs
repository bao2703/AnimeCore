using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class VideoAds : Advertisement
    {
        public string Video { get; set; }

        [Required]
        public VideoAdsLocation VideoAdsLocation { get; set; }
    }
}