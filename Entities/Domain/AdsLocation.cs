using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum LocationType
    {
        Monopoly,
        Share
    }

    public enum AdsType
    {
        Video,
        Banner
    }

    public class AdsLocation : Entity
    {
        [Required]
        public string Name { get; set; }

        public int Price { get; set; }

        public string Desciption { get; set; }

        [Display(Name = "Ads type")]
        public AdsType AdsType { get; set; }

        [Display(Name = "Location type")]
        public LocationType LocationType { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}