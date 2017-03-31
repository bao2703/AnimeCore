using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Areas.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}