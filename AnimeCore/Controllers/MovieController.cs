using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositories;

namespace AnimeCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IMovieRepository _movieRepository;
        private readonly IVideoAdsRepository _videoAdsRepository;

        public MovieController(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork,
            IMovieRepository movieRepository, IVideoAdsRepository videoAdsRepository)
        {
            _appSettings = appSettings.Value;
            _movieRepository = movieRepository;
            _videoAdsRepository = videoAdsRepository;
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
            if (movie == null)
            {
                return View("Error");
            }
            Advertisement advertisement;
            if (_movieRepository.IsPopular(movie.Id))
            {
                advertisement = _videoAdsRepository.GetActiveVideos("Popular").PickRandom();
            }
            else if (_movieRepository.IsNewest(movie.Id))
            {
                advertisement = _videoAdsRepository.GetActiveVideos("Newest").PickRandom();
            }
            else
            {
                advertisement = _videoAdsRepository.GetActiveVideos("Normal").PickRandom();
            }
            ViewData["Advertisement"] = advertisement;
            return View(movie);
        }
    }
}