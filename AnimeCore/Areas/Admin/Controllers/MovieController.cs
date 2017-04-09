using Entities.Domain;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class MovieController : DefaultController<Movie, IMovieRepository>
    {
        public MovieController(IUnitOfWork unitOfWork, IMovieRepository repository) : base(unitOfWork, repository)
        {
        }

        protected override string AddPartialViewName { get; set; } = "_AddEditPartial";
        protected override string EditPartialViewName { get; set; } = "_AddEditPartial";
    }
}