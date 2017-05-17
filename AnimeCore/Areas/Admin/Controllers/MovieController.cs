using System;
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
        public async Task<IActionResult> Add(Movie model, int[] genres, IFormFile file)
        {
            if (file == null)
            {
                ModelState.AddModelError(string.Empty, "Image is required.");
            }

            if (ModelState.IsValid)
            {
                var filePath = Constant.ImagesFolderPath + DateTime.Now.ToFileTime() + file.FileName;
                await Helper.CopyFileToAsync(filePath, file);
                model.Image = filePath;

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
        public async Task<IActionResult> Edit(Movie model, int[] genres, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var filePath = Constant.ImagesFolderPath + DateTime.Now.ToFileTime() + file.FileName;
                    model.Image = filePath;
                    await Helper.CopyFileToAsync(filePath, file);
                }

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
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _movieRepository.FindById(id);
            _movieRepository.Remove(model);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}