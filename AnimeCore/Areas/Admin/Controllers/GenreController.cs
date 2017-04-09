using Entities.Domain;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class GenreController : DefaultController<Genre, IGenreRepository>
    {
        public GenreController(IUnitOfWork unitOfWork, IGenreRepository repository) : base(unitOfWork, repository)
        {
        }

        protected override string AddPartialViewName { get; set; } = "_AddEditPartial";
        protected override string EditPartialViewName { get; set; } = "_AddEditPartial";
    }
}