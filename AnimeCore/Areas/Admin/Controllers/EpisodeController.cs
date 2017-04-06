using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
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

        public EpisodeController(IEpisodeService episodeService, IMovieService movieService)
        {
            _episodeService = episodeService;
            _movieService = movieService;
        }

        public IActionResult Index(int movieId)
        {
            var movie = _movieService.FindBy(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["Movie"] = movie;
            var episode = _episodeService.OrderByName(movie.Episodes);
            var model = episode.Select(x => new EpisodeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url
            });
            return View(model);
        }

        public IActionResult Add(int movieId)
        {
            var model = new AddEditEpisodeViewModel
            {
                MovieId = movieId
            };
            ViewData["Action"] = "Add";
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddEditEpisodeViewModel model)
        {
            ViewData["Action"] = "Add";
            if (ModelState.IsValid)
            {
                var genre = new Episode
                {
                    Name = model.Name,
                    Url = model.Url,
                    Movie = new Movie {Id = model.MovieId}
                };
                await _episodeService.AddAsync(genre);
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var episode = _episodeService.FindBy(id);
            if (episode == null)
            {
                return NotFound();
            }
            var model = new AddEditEpisodeViewModel
            {
                Id = episode.Id,
                Name = episode.Name,
                Url = episode.Url,
                MovieId = episode.Movie.Id
            };
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditEpisodeViewModel model)
        {
            ViewData["Action"] = "Edit";
            if (ModelState.IsValid)
            {
                var episode = _episodeService.FindBy(model.Id);
                if (episode == null)
                {
                    return NotFound();
                }
                episode.Name = model.Name;
                episode.Url = model.Url;
                await _episodeService.UpdateAsync(episode);
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var episode = _episodeService.FindBy(id);
            if (episode == null)
            {
                return NotFound();
            }
            var model = new EpisodeViewModel
            {
                Id = episode.Id,
                Name = episode.Name,
                Url = episode.Url
            };
            return PartialView("_DeletePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EpisodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var episode = _episodeService.FindBy(model.Id);
                if (episode == null)
                {
                    return NotFound();
                }
                await _episodeService.RemoveAsync(episode);
                return JsonStatus.Ok;
            }
            return PartialView("_DeletePartial", model);
        }
    }
}