using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class VideoAdsController : DefaultController<VideoAds, IVideoAdsRepository>
    {
        private readonly IVideoAdsLocationRepository _videoAdsLocationRepository;

        public VideoAdsController(IUnitOfWork unitOfWork, IVideoAdsRepository repository,
            IVideoAdsLocationRepository videoAdsLocationRepository) : base(unitOfWork, repository)
        {
            _videoAdsLocationRepository = videoAdsLocationRepository;
        }

        protected override string AddPartialViewName { get; set; } = "_AddEditPartial";
        protected override string EditPartialViewName { get; set; } = "_AddEditPartial";

        public override IActionResult Add()
        {
            ViewData["Action"] = "Add";
            ViewData["AdsLocationList"] = _videoAdsLocationRepository.ToList();
            return base.Add();
        }

        public override Task<IActionResult> Add(VideoAds model)
        {
            ViewData["Action"] = "Add";
            ViewData["AdsLocationList"] = _videoAdsLocationRepository.ToList();
            return base.Add(model);
        }

        public override IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            ViewData["AdsLocationList"] = _videoAdsLocationRepository.ToList();
            return base.Edit(id);
        }

        public override Task<IActionResult> Edit(VideoAds model)
        {
            ViewData["Action"] = "Edit";
            ViewData["AdsLocationList"] = _videoAdsLocationRepository.ToList();
            return base.Edit(model);
        }
    }
}