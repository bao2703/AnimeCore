using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class EpisodeController : AdminController
    {
        private readonly IMovieService _movieService;
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IMovieService movieService, IEpisodeService episodeService)
        {
            _movieService = movieService;
            _episodeService = episodeService;
        }

        public IActionResult Index(int movieId)
        {
            var movie = _movieService.FindBy(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["Movie"] = movie.Name;
            var model = _episodeService.OrderByName(movie.Episodes);
            return View(model);
        }
    }
}