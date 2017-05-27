using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class Movie : TimestampEntity
    {
        public Movie()
        {
            GenreMovies = new HashSet<GenreMovie>();
            Episodes = new HashSet<Episode>();
            Likes = new HashSet<Like>();
            Release = DateTime.Now;
            Status = MovieStatus.Ongoing;
            Image = "null";
            Slide = "null";
        }

        [Required]
        public string Name { get; set; }

        public DateTime Release { get; set; }

        public string Description { get; set; }

        public long View { get; set; }

        public string Image { get; set; }

        public string Slide { get; set; }

        public string Slug { get; set; }

        public string Fansub { get; set; }

        public MovieStatus Status { get; set; }

        public ICollection<GenreMovie> GenreMovies { get; set; }

        public ICollection<Episode> Episodes { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}