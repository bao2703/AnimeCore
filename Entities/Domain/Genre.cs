using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class Genre : Entity
    {
        public Genre()
        {
            GenreMovies = new HashSet<GenreMovie>();
        }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
            MinimumLength = 3)]
        public string Name { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public ICollection<GenreMovie> GenreMovies { get; set; }
    }
}