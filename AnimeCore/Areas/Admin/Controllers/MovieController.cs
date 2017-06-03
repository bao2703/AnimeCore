using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class MovieController : AdminController
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork unitOfWork, IMovieRepository movieRepository)
        {
            _unitOfWork = unitOfWork;
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var model = _movieRepository.GetAll();
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new Movie();
            ViewData["SelectGenres"] = 1;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Movie model, int[] genres, IFormFile image, IFormFile slide)
        {
            if (image == null)
            {
                ModelState.AddModelError(string.Empty, "Image is required.");
            }

            if (ModelState.IsValid)
            {
                await UpdateFileIfExistAsync(model, image, slide);

                foreach (var genre in genres)
                {
                    model.GenreMovies.Add(new GenreMovie
                    {
                        GenreId = genre
                    });
                }

                _movieRepository.Add(model);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SelectGenres"] = genres;
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _movieRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movie model, int[] genres, IFormFile image, IFormFile slide)
        {
            if (ModelState.IsValid)
            {
                var movie = _movieRepository.FindById(model.Id);
                if (movie == null)
                {
                    return NotFound();
                }

                await UpdateFileIfExistAsync(movie, image, slide);

                UpdateGenre(movie, genres);

                movie.Name = model.Name;
                movie.Status = model.Status;
                movie.Release = model.Release;
                movie.Description = model.Description;

                _movieRepository.Update(movie);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = _movieRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_DeletePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Movie model)
        {
            _movieRepository.Remove(model);
            await _unitOfWork.SaveChangesAsync();
            return JsonStatus.Ok;
        }

        private void UpdateGenre(Movie movie, int[] genres)
        {
            foreach (var genre in genres)
            {
                if (movie.GenreMovies.All(x => x.GenreId != genre))
                {
                    movie.GenreMovies.Add(new GenreMovie
                    {
                        GenreId = genre
                    });
                }
            }

            foreach (var gm in movie.GenreMovies.ToList())
            {
                if (genres.All(x => x != gm.GenreId))
                {
                    movie.GenreMovies.Remove(gm);
                }
            }
        }

        private async Task UpdateFileIfExistAsync(Movie movie, IFormFile image, IFormFile slide)
        {
            if (image != null)
            {
                movie.Image = await UploadAsync(image);
            }
            if (slide != null)
            {
                movie.Slide = await UploadAsync(slide);
            }
        }
    }
}