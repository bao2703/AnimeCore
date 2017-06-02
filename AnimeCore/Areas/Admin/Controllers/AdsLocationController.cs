using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdsLocationController : AdminController
    {
        private readonly IAdsLocationRepository _adsLocationRepository;

        public AdsLocationController(IAdsLocationRepository adsLocationRepository)
        {
            _adsLocationRepository = adsLocationRepository;
        }

        public IActionResult Index(LocationType locationType)
        {
            var model = _adsLocationRepository.GetAll(locationType);
            ViewData["LocationType"] = locationType.ToString();
            return View(model);
        }
    }
}