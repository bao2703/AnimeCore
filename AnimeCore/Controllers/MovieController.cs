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

        // GET: /Movie/Index
        public IActionResult Index(string searchString)
        {
            ViewData["SearchString"] = searchString;
            ViewData[Constant.PageSize] = _appSettings.PageSize;
            return View();
        }

        // GET: /Movie/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var movie = _movieService.FindBy((int) id);
            return movie == null ? View("Error") : View(movie);
        }

        // GET: /Movie/Watch/5
        public IActionResult Watch(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var movie = _movieService.FindBy((int) id);
            return movie == null ? View("Error") : View(movie);
        }
    }
}