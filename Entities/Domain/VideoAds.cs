namespace Entities.Domain
{
    public class VideoAds : Advertisement
    {
        public int? AdsLocationId { get; set; }

        public AdsLocation AdsLocation { get; set; }
    }
}