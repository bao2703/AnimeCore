using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public enum AdsType
    {
        Video,
        Banner
    }

    public abstract class AdsLocation : Entity
    {
        [Required]
        public string Name { get; set; }

        public int Price { get; set; }

        public string Desciption { get; set; }
    }
}