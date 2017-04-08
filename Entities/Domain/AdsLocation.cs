using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class AdsLocation : Entity
    {
        [Required]
        public string Name { get; set; }

        public string Desciption { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}