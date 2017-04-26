using System;
using System.Collections.Generic;
using System.IO;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Movie model, int[] genres, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var filePath = Constant.ImagesFolderPath + DateTime.Now.ToFileTime() + file.FileName;

                using (var stream = new FileStream(Constant.RootPath + filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                model.Image = filePath;
                model.GenreMovies = new List<GenreMovie>();
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
    }
}