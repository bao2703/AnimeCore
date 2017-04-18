using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class BannerAdsLocationController : AdminController
    {
        private readonly IBannerAdsLocationRepository _bannerAdsLocationRepository;

        public BannerAdsLocationController(IBannerAdsLocationRepository bannerAdsLocationRepository)
        {
            _bannerAdsLocationRepository = bannerAdsLocationRepository;
        }

        public IActionResult Index()
        {
            var model = _bannerAdsLocationRepository.GetAll();
            return View(model);
        }
    }
}