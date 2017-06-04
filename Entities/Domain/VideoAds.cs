using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Domain
{
    public class VideoAds : Advertisement
    {
        public VideoAds()
        {
            SkipIn = 5;
        }

        [Required]
        [Display(Name = "Skip in")]
        [Range(1, 30)]
        public int SkipIn { get; set; }
    }
}