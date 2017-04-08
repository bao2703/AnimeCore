using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.EpisodeViewModels;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class EpisodeController : AdminController
    {
        private readonly IUnitOfWork _unitOfWork;

        public EpisodeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int movieId)
        {
            var movie = _unitOfWork.MovieRepository.FindById(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["Movie"] = movie;
            var episode = _unitOfWork.EpisodeRepository.OrderByDescendingName(movie.Episodes);
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
                var episode = new Episode
                {
                    Name = model.Name,
                    Url = model.Url,
                    Movie = new Movie {Id = model.MovieId}
                };
                _unitOfWork.MovieRepository.Attach(episode.Movie);
                await _unitOfWork.EpisodeRepository.AddAsync(episode);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var episode = _unitOfWork.EpisodeRepository.FindById(id);
            if (episode == null)
            {
                return NotFound();
            }
            var model = new AddEditEpisodeViewModel
            {
                Id = episode.Id,
                Name = episode.Name,
                Url = episode.Url
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
                var episode = _unitOfWork.EpisodeRepository.FindById(model.Id);
                if (episode == null)
                {
                    return NotFound();
                }
                episode.Name = model.Name;
                episode.Url = model.Url;
                _unitOfWork.EpisodeRepository.Update(episode);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var episode = _unitOfWork.EpisodeRepository.FindById(id);
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
                var episode = _unitOfWork.EpisodeRepository.FindById(model.Id);
                if (episode == null)
                {
                    return NotFound();
                }
                _unitOfWork.EpisodeRepository.Remove(episode);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_DeletePartial", model);
        }
    }
}