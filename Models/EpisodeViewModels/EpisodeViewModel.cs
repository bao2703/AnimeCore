﻿using System.ComponentModel.DataAnnotations;

namespace Models.EpisodeViewModels
{
    public class EpisodeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Episode")]
        public string Name { get; set; }

        public string Source { get; set; }
    }
}