using System.Collections.Generic;

namespace Entities.Domain
{
    public class Genre : Entity
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public virtual ICollection<GenreMovie> MovieGenre { get; set; }
    }
}