using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdvertisementController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}