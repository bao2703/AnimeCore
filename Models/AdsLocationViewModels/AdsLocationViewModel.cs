using System.ComponentModel.DataAnnotations;

namespace Models.AdsLocationViewModels
{
    public class AdsLocationViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Name { get; set; }

        public string Desciption { get; set; }
    }
}