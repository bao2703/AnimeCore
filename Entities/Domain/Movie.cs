using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class Movie : TrackAbleEntity
    {
        public Movie()
        {
            Release = DateTime.Now;
            Status = Status.Ongoing;
        }

        [Required]
        public string Name { get; set; }

        public float Rating { get; set; }

        public int Vote { get; set; }

        public string Quality { get; set; }

        public DateTime Release { get; set; }

        public string Description { get; set; }

        public long Viewed { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }

        public string Fansub { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<GenreMovie> Genres { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
