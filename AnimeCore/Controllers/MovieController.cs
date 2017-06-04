using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Repositories;
using Services;

namespace AnimeCore.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IVideoAdsRepository _videoAdsRepository;

        public MovieController(IOptionsSnapshot<AppSettings> appSettings,
            IMovieRepository movieRepository, IVideoAdsRepository videoAdsRepository, IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _appSettings = appSettings.Value;
            _movieRepository = movieRepository;
            _videoAdsRepository = videoAdsRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        // GET: /Movie/Index
        public IActionResult Index(string searchString, string releaseYear)
        {
            ViewData[Constant.SearchString] = searchString;
            ViewData[Constant.PageSize] = _appSettings.PageSize;
            ViewData["ReleaseYear"] = releaseYear;
            return View();
        }

        // GET: /Movie/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = _movieRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["HasLike"] = false;
            if (User.Identity.IsAuthenticated)
            {
                ViewData["HasLike"] = _movieRepository.HasLike(await _userService.GetUserAsync(User), model);
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

        [Authorize]
        public async Task<IActionResult> Like(int id)
        {
            var movie = _movieRepository.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            if (!_movieRepository.HasLike(await _userService.GetUserAsync(User), movie))
            {
                _movieRepository.Like(await _userService.GetUserAsync(User), movie);
                _unitOfWork.SaveChanges();
            }
            return RedirectToAction("Details", new {id});
        }

        [Authorize]
        public async Task<IActionResult> UnLike(int id)
        {
            var movie = _movieRepository.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            _movieRepository.UnLike(await _userService.GetUserAsync(User), movie);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Details", new {id});
        }
    }
}