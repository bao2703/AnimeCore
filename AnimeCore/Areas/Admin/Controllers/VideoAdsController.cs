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
        private readonly IAdsLocationRepository _adsLocationRepository;

        public VideoAdsController(IUnitOfWork unitOfWork, IVideoAdsRepository videoAdsRepository, IAdsLocationRepository adsLocationRepository)
        {
            _unitOfWork = unitOfWork;
            _videoAdsRepository = videoAdsRepository;
            _adsLocationRepository = adsLocationRepository;
        }

        public IActionResult Index()
        {
            var model = _videoAdsRepository.GetAll();
            return View(model);
        }

        public IActionResult Add(int customerId)
        {
            ViewData["Action"] = "Add";
            return PartialView("_AddEditPartial", new VideoAds
            {
                CustomerId = customerId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VideoAds model)
        {
            ViewData["Action"] = "Add";
            if (model.StartDate < DateTime.Today)
            {
                ModelState.AddModelError(string.Empty, "Start date must be greater than current day");
            }
            if (ModelState.IsValid)
            {
                model.Price = _adsLocationRepository.FindById(model.AdsLocationId).Price;

                await _videoAdsRepository.AddAsync(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var model = _videoAdsRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VideoAds model)
        {
            ViewData["Action"] = "Edit";
            if (ModelState.IsValid)
            {
                model.Price = _adsLocationRepository.FindById(model.AdsLocationId).Price;

                _videoAdsRepository.Update(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var model = _videoAdsRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_DeletePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Delete(VideoAds model)
        {
            _videoAdsRepository.Remove(model);
            await _unitOfWork.SaveChangesAsync();
            return JsonStatus.Ok;
        }

        public IActionResult Preview(string source)
        {
            return PartialView("_PreviewPartial", source);
        }
    }
}