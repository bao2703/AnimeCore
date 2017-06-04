using System.Threading.Tasks;
using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace AnimeCore.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IBannerAdsRepository _bannerAdsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideoAdsRepository _videoAdsRepository;

        public AdvertisementController(IUnitOfWork unitOfWork, IBannerAdsRepository bannerAdsRepository,
            IVideoAdsRepository videoAdsRepository)
        {
            _unitOfWork = unitOfWork;
            _bannerAdsRepository = bannerAdsRepository;
            _videoAdsRepository = videoAdsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> BannerOnClick(int id)
        {
            var banner = _bannerAdsRepository.FindById(id);
            banner.Click = banner.Click + 1;
            await _unitOfWork.SaveChangesAsync();
            return JsonStatus.Ok;
        }

        [HttpPost]
        public async Task<IActionResult> VideoOnClick(int id)
        {
            var video = _videoAdsRepository.FindById(id);
            video.Click = video.Click + 1;
            await _unitOfWork.SaveChangesAsync();
            return JsonStatus.Ok;
        }

        [HttpPost]
        public async Task<IActionResult> VideoOnSkip(int id)
        {
            var video = _videoAdsRepository.FindById(id);
            video.View = video.View + 1;
            await _unitOfWork.SaveChangesAsync();
            return JsonStatus.Ok;
        }
    }
}