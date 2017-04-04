using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.GenreViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class GenreController : AdminController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var model = _genreService.ToList().Select(x => new GenreViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Title = x.Title
            }).ToList();
            return View(model);
        }

        public IActionResult AddEdit(int id)
        {
            var model = new GenreViewModel();
            ViewData["IsAdd"] = true;
            var genre = _genreService.FindBy(id);
            if (genre != null)
            {
                model.Id = genre.Id;
                model.Name = genre.Name;
                model.Title = genre.Title;
                ViewData["IsAdd"] = false;
            }
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var genre = _genreService.FindBy(model.Id);
                if (genre != null)
                {
                    genre.Name = model.Name;
                    genre.Title = model.Title;
                    await _genreService.UpdateAsync(genre);
                }
                else
                {
                    genre = new Genre
                    {
                        Name = model.Name,
                        Title = model.Title
                    };
                    await _genreService.AddAsync(genre);
                }
                return Json(new
                {
                    status = "Ok"
                });
            }
            return PartialView("_AddEditPartial", model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreService.FindByAsync(id);
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
    }
}