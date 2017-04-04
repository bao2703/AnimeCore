using System.ComponentModel.DataAnnotations;

namespace Models.GenreViewModels
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3)]
        public string Name { get; set; }

        public string Title { get; set; }
    }
}