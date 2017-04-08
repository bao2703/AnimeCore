using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.GenreViewModels;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class GenreController : AdminController
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork, IGenreRepository genreRepository)
        {
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            var model = _genreRepository.GetAll().Select(x => new GenreViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Title = x.Title
            });
            return View(model);
        }

        public IActionResult Add()
        {
            ViewData["Action"] = "Add";
            var model = new GenreViewModel();
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var genre = _genreRepository.FindById(id);
            if (genre == null)
            {
                return NotFound();
            }
            var model = new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name,
                Title = genre.Title
            };
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GenreViewModel model)
        {
            ViewData["Action"] = "Add";
            if (ModelState.IsValid)
            {
                var genre = new Genre
                {
                    Name = model.Name,
                    Title = model.Title
                };
                await _genreRepository.AddAsync(genre);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GenreViewModel model)
        {
            ViewData["Action"] = "Edit";
            if (ModelState.IsValid)
            {
                var genre = _genreRepository.FindById(model.Id);
                if (genre != null)
                {
                    genre.Name = model.Name;
                    genre.Title = model.Title;
                    _genreRepository.Update(genre);
                    await _unitOfWork.SaveChangesAsync();
                }
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var genre = _genreRepository.FindById(id);
            if (genre != null)
            {
                var model = new GenreViewModel
                {
                    Id = genre.Id,
                    Name = genre.Name,
                    Title = genre.Title
                };
                return PartialView("_DeletePartial", model);
            }
            return PartialView("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = _genreRepository.FindById(model.Id);
                if (role != null)
                {
                    _genreRepository.Remove(role);
                    await _unitOfWork.SaveChangesAsync();
                    return JsonStatus.Ok;
                }
            }
            return PartialView("_DeletePartial", model);
        }
    }
}