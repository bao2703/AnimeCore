using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.EpisodeViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class EpisodeController : AdminController
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMovieService _movieService;

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
            ViewData["Movie"] = movie;
            var model = _episodeService.OrderByName(movie.Episodes);
            return View(model);
        }

        public IActionResult AddEdit(int id, int movieId)
        {
            var model = new AddEditEpisodeViewModel();
            var episode = _episodeService.FindBy(id);
            ViewData["IsAdd"] = true;
            if (episode != null)
            {
                model.Id = episode.Id;
                model.Name = episode.Name;
                model.Url = episode.Url;
                ViewData["IsAdd"] = false;
            }
            model.MovieId = movieId;
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(AddEditEpisodeViewModel model, bool isAdd)
        {
            ViewData["IsAdd"] = isAdd;
            if (ModelState.IsValid)
            {
                var episode = _episodeService.FindBy(model.Id);
                if (episode != null)
                {
                    episode.Name = model.Name;
                    episode.Url = model.Url;
                    await _episodeService.UpdateAsync(episode);
                }
                else
                {
                    episode = new Episode
                    {
                        Name = model.Name,
                        Url = model.Url,
                        Movie = new Movie {Id = model.MovieId}
                    };
                    await _episodeService.AddAsync(episode);
                }
                return Json(new
                {
                    status = "Ok"
                });
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var episode = _episodeService.FindBy(id);
            if (episode != null)
            {
                var model = new EpisodeViewModel
                {
                    Id = episode.Id,
                    Name = episode.Name,
                    Url = episode.Url
                };
                return PartialView("_DeletePartial", model);
            }
            return PartialView("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EpisodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var episode = _episodeService.FindBy(model.Id);
                if (episode != null)
                {
                    await _episodeService.RemoveAsync(episode);
                    return Json(new
                    {
                        status = "Ok"
                    });
                }
            }
            return PartialView("_DeletePartial", model);
        }
    }
}