using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}