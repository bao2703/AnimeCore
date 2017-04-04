using Microsoft.AspNetCore.Mvc;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class MovieController : AdminController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}