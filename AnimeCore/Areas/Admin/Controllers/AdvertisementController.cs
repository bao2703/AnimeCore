using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdvertisementController : DefaultController<Advertisement, IAdvertisementRepository>
    {
        private readonly IAdsLocationRepository _adsLocationRepository;

        public AdvertisementController(IUnitOfWork unitOfWork, IAdvertisementRepository repository,
            IAdsLocationRepository adsLocationRepository) : base(unitOfWork, repository)
        {
            _adsLocationRepository = adsLocationRepository;
        }

        protected override string AddPartialViewName { get; set; } = "_AddEditPartial";
        protected override string EditPartialViewName { get; set; } = "_AddEditPartial";

        public override IActionResult Add()
        {
            ViewData["Action"] = "Add";
            ViewData["AdsLocationList"] = _adsLocationRepository.ToList();
            return base.Add();
        }

        public override Task<IActionResult> Add(Advertisement model)
        {
            ViewData["Action"] = "Add";
            ViewData["AdsLocationList"] = _adsLocationRepository.ToList();
            return base.Add(model);
        }

        public override IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            ViewData["AdsLocationList"] = _adsLocationRepository.ToList();
            return base.Edit(id);
        }

        public override Task<IActionResult> Edit(Advertisement model)
        {
            ViewData["Action"] = "Edit";
            ViewData["AdsLocationList"] = _adsLocationRepository.ToList();
            return base.Edit(model);
        }
    }
}