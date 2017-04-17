using System.Collections.Generic;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.ViewComponents
{
    [ViewComponent(Name = "Banner")]
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<BannerAds> model)
        {
            return View(model);
        }
    }
}