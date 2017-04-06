using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
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
            });
            return View(model);
        }

        public IActionResult AddEdit(int id)
        {
            var model = new GenreViewModel();
            ViewData["Action"] = "Add";
            var genre = _genreService.FindBy(id);
            if (genre != null)
            {
                model.Id = genre.Id;
                model.Name = genre.Name;
                model.Title = genre.Title;
                ViewData["Action"] = "Edit";
            }
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
                await _genreService.AddAsync(genre);
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
                var genre = _genreService.FindBy(model.Id);
                if (genre != null)
                {
                    genre.Name = model.Name;
                    genre.Title = model.Title;
                    await _genreService.UpdateAsync(genre);
                }
                return JsonStatus.Ok;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _genreService.FindByAsync(model.Id);
                if (role != null)
                {
                    await _genreService.RemoveAsync(role);
                    return JsonStatus.Ok;
                }
            }
            return PartialView("_DeletePartial", model);
        }
    }
}