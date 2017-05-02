using System;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class VideoAdsController : AdminController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideoAdsRepository _videoAdsRepository;

        public VideoAdsController(IUnitOfWork unitOfWork, IVideoAdsRepository videoAdsRepository)
        {
            _unitOfWork = unitOfWork;
            _videoAdsRepository = videoAdsRepository;
        }

        public IActionResult Index()
        {
            var model = _videoAdsRepository.GetAll();
            return View(model);
        }

        public IActionResult Add(int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            return PartialView("_AddEditPartial", new VideoAds());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VideoAds model, int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            if (model.StartDate < DateTime.Today)
            {
                ModelState.AddModelError(string.Empty, "Start date must be greater than current day");
            }
            if (ModelState.IsValid)
            {
                model.CustomerId = customerId;
                await _videoAdsRepository.AddAsync(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Preview(string source)
        {
            return PartialView("_PreviewPartial", source);
        }
    }
}