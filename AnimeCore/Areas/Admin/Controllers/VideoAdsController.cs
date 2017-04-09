using Entities.Domain;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class VideoAdsController : DefaultController<VideoAds, IVideoAdsRepository>
    {
        public VideoAdsController(IUnitOfWork unitOfWork, IVideoAdsRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}