using Entities.Domain;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class AdsLocationController : DefaultController<AdsLocation, IAdsLocationRepository>
    {
        public AdsLocationController(IUnitOfWork unitOfWork, IAdsLocationRepository repository)
            : base(unitOfWork, repository)
        {
        }

        protected override string AddPartialViewName { get; set; } = "_AddEditPartial";
        protected override string EditPartialViewName { get; set; } = "_AddEditPartial";
    }
}