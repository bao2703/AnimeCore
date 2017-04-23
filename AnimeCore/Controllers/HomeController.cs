using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Error/{statusCode}")]
        public IActionResult Error(int? statusCode)
        {
            switch (statusCode)
            {
                case 403:
                    return View("AccessDenied");
                case 404:
                    return View("NotFound");
                default:
                    return View();
            }
        }
    }
}