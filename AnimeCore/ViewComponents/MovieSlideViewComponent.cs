using System.Collections.Generic;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.ViewComponents
{
    [ViewComponent(Name = "MovieSlide")]
    public class MovieSlideViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Movie> model, string title)
        {
            ViewData[Constant.SlideTitle] = title;
            return View(model);
        }
    }
}