using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sakura.AspNetCore;
using Services;

namespace AnimeCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService, IOptions<AppSettings> appSettings)
        {
            _movieService = movieService;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index(int pageIndex = 1)
        {
            var model = _movieService.ToList();
            return View(model.ToPagedList(_appSettings.PageSize, pageIndex));
        }

        public IActionResult Details(int id)
        {
            var model = _movieService.FindBy(id);
            return View(model);
        }
    }
}