using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdsLocationController : AdminController
    {
        private readonly IAdsLocationRepository _adsLocationRepository;

        public AdsLocationController(IAdsLocationRepository adsLocationRepository)
        {
            _adsLocationRepository = adsLocationRepository;
        }
    }
}