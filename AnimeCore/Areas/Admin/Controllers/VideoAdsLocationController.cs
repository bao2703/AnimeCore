using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class VideoAdsLocationController : AdminController
    {
        private readonly IVideoAdsLocationRepository _videoAdsLocationRepository;

        public VideoAdsLocationController(IVideoAdsLocationRepository videoAdsLocationRepository)
        {
            _videoAdsLocationRepository = videoAdsLocationRepository;
        }
    }
}