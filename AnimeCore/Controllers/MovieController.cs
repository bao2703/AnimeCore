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
        public IActionResult Details(int id)
        {
            var model = _movieRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: /Movie/Watch/5
        public IActionResult Watch(int id)
        {
            var model = _movieRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            Advertisement advertisement;
            if (_movieRepository.IsPopular(model.Id))
            {
                advertisement = _videoAdsRepository.GetActiveVideos("Popular").PickRandom();
            }
            else if (_movieRepository.IsNewest(model.Id))
            {
                advertisement = _videoAdsRepository.GetActiveVideos("Newest").PickRandom();
            }
            else
            {
                advertisement = _videoAdsRepository.GetActiveVideos("Normal").PickRandom();
            }
            ViewData["Advertisement"] = advertisement;
            return View(model);
        }
    }
}