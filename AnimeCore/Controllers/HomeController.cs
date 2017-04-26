using Microsoft.AspNetCore.Mvc;
using Models;

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
            var model = new ErrorViewModel
            {
                Title = "Error",
                Description = " Sorry, an error has occured!"
            };
            switch (statusCode)
            {
                case 403:
                    model.Title = "Access Denied";
                    model.Description = "Sorry, an error has occured, you need permission to access!";
                    break;
                case 404:
                    model.Title = "404 Not Found";
                    model.Description = "Sorry, an error has occured, requested page not found!";
                    break;
                default:
                    break;
            }
            return View(model);
        }
    }
}