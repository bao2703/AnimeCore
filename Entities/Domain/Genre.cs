using System.Collections.Generic;

namespace Entities.Domain
{
    public class Genre : Entity
    {
        public Genre()
        {
            GenreMovies = new HashSet<GenreMovie>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public ICollection<GenreMovie> GenreMovies { get; set; }
    }
}