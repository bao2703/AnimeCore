using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdvertisementController : AdminController
    {
        private readonly IAdsLocationRepository _adsLocationRepository;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdvertisementController(IUnitOfWork unitOfWork, IAdvertisementRepository advertisementRepository,
            IAdsLocationRepository adsLocationRepository)
        {
            _unitOfWork = unitOfWork;
            _advertisementRepository = advertisementRepository;
            _adsLocationRepository = adsLocationRepository;
        }

        public IActionResult Add(int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["AdsLocationList"] = _adsLocationRepository.ToList();
            return PartialView("_AddEditPartial", new Advertisement());
        }
    }
}