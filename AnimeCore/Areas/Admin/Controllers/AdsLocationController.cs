using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.AdsLocationViewModels;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdsLocationController : AdminController
    {
        private readonly IAdsLocationRepository _adsLocationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdsLocationController(IUnitOfWork unitOfWork, IAdsLocationRepository adsLocationRepository)
        {
            _unitOfWork = unitOfWork;
            _adsLocationRepository = adsLocationRepository;
        }

        public IActionResult Index()
        {
            var model = _adsLocationRepository.GetAll().Select(x => new AdsLocationViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Desciption = x.Desciption
            });
            return View(model);
        }

        public IActionResult Add()
        {
            ViewData["Action"] = "Add";
            var model = new AdsLocationViewModel();
            return PartialView("_AddEditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AdsLocationViewModel model)
        {
            ViewData["Action"] = "Add";
            if (ModelState.IsValid)
            {
                var adsLocation = new AdsLocation
                {
                    Name = model.Name,
                    Desciption = model.Desciption
                };
                await _adsLocationRepository.AddAsync(adsLocation);
                await _unitOfWork.SaveChangesAsync();
                return JsonStatus.Ok;
            }
            return PartialView("_AddEditPartial", model);
        }
    }
}