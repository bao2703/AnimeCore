using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services;

namespace AnimeCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _movieService.FindBy(id);
            return View(model);
        }
    }
}