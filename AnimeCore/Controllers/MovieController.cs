using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositories;

namespace AnimeCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IMovieRepository _movieRepository;

        public MovieController(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork,
            IMovieRepository movieRepository)
        {
            _appSettings = appSettings.Value;
            _movieRepository = movieRepository;
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
            var movie = _movieRepository.FindById((int) id);
            return movie == null ? View("Error") : View(movie);
        }

        // GET: /Movie/Watch/5
        public IActionResult Watch(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var movie = _movieRepository.FindById((int) id);
            return movie == null ? View("Error") : View(movie);
        }
    }
}