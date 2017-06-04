using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.EpisodeViewModels;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class EpisodeController : AdminController
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EpisodeController(IUnitOfWork unitOfWork, IEpisodeRepository episodeRepository,
            IMovieRepository movieRepository)
        {
            _unitOfWork = unitOfWork;
            _episodeRepository = episodeRepository;
            _movieRepository = movieRepository;
        }

        public IActionResult Index(int movieId)
        {
            var movie = _movieRepository.FindById(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["Movie"] = movie;
            var episode = _episodeRepository.OrderByDescendingName(movie.Episodes);
            var model = episode.Select(x => new EpisodeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Source = x.Source
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
        public async Task<IActionResult> Add(AddEditEpisodeViewModel model, IFormFile file)
        {
            ViewData["Action"] = "Add";
            if (file == null)
            {
                ModelState.AddModelError(string.Empty, "Video is required.");
            }
            if (ModelState.IsValid)
            {
                var episode = new Episode
                {
                    Name = model.Name,
                    Source = await UploadAsync(file),
                    MovieId = model.MovieId
                };

                await _episodeRepository.AddAsync(episode);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var episode = _episodeRepository.FindById(id);
            if (episode == null)
            {
                return NotFound();
            }
            var model = new AddEditEpisodeViewModel
            {
                Id = episode.Id,
                Name = episode.Name,
                Source = episode.Source
            };
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditEpisodeViewModel model, IFormFile file)
        {
            ViewData["Action"] = "Edit";
            if (ModelState.IsValid)
            {
                var episode = _episodeRepository.FindById(model.Id);
                if (episode == null)
                {
                    return NotFound();
                }
                episode.Name = model.Name;
                if (file != null)
                {
                    episode.Source = await UploadAsync(file);
                }
                _episodeRepository.Update(episode);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var episode = _episodeRepository.FindById(id);
            if (episode == null)
            {
                return NotFound();
            }
            var model = new EpisodeViewModel
            {
                Id = episode.Id,
                Name = episode.Name,
                Source = episode.Source
            };
            return PartialView("_DeletePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EpisodeViewModel model)
        {
            var episode = _episodeRepository.FindById(model.Id);
            if (episode == null)
            {
                return NotFound();
            }
            _episodeRepository.Remove(episode);
            await _unitOfWork.SaveChangesAsync();
            return JsonStatus.Ok;
        }

        public IActionResult Preview(string source)
        {
            return PartialView("_PreviewPartial", source);
        }
    }
}