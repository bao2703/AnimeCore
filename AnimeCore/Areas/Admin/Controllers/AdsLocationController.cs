using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdsLocationController : AdminController
    {
        private readonly IAdsLocationRepository _adsLocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdsLocationController(IAdsLocationRepository adsLocationRepository, IUnitOfWork unitOfWork)
        {
            _adsLocationRepository = adsLocationRepository;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(LocationType locationType = LocationType.Banner)
        {
            var model = _adsLocationRepository.GetAll(locationType);
            ViewData["LocationType"] = locationType;
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _adsLocationRepository.FindById(id);
            if (model == null)
            {
                return NotFound();
            }
            return PartialView("_EditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdsLocation model)
        {
            if (ModelState.IsValid)
            {
                _adsLocationRepository.Update(model);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_EditPartial", model);
        }
    }
}