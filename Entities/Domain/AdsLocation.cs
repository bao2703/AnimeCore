using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public abstract class AdsLocation : Entity
    {
        [Required]
        public string Name { get; set; }

        public string Desciption { get; set; }
    }
}