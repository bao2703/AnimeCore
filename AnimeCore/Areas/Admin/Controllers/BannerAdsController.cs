using System;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class BannerAdsController : AdminController
    {
        private readonly IBannerAdsRepository _bannerAdsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BannerAdsController(IUnitOfWork unitOfWork, IBannerAdsRepository bannerAdsRepository)
        {
            _unitOfWork = unitOfWork;
            _bannerAdsRepository = bannerAdsRepository;
        }

        public IActionResult Index()
        {
            var model = _bannerAdsRepository.GetAll();
            return View(model);
        }

        public IActionResult Add(int customerId)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            return PartialView("_AddEditPartial", new BannerAds());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BannerAds model, int customerId, IFormFile file)
        {
            ViewData["Action"] = "Add";
            ViewData["CustomerId"] = customerId;
            if (file == null)
            {
                ModelState.AddModelError(string.Empty, "Image is required.");
            }
            if (ModelState.IsValid)
            {
                var filePath = Constant.ImagesFolderPath + DateTime.Now.ToFileTime() + file.FileName;
                await Helper.CopyFileToAsync(filePath, file);
                model.Source = filePath;
                model.CustomerId = customerId;
                await _bannerAdsRepository.AddAsync(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            var model = _bannerAdsRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BannerAds model, IFormFile file)
        {
            ViewData["Action"] = "Edit";

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var filePath = Constant.ImagesFolderPath + DateTime.Now.ToFileTime() + file.FileName;
                    model.Source = filePath;
                    await Helper.CopyFileToAsync(filePath, file);
                }

                _bannerAdsRepository.Update(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }

        public IActionResult Delete(int id)
        {
            var model = _bannerAdsRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_DeletePartial", model);
        }
    }
}