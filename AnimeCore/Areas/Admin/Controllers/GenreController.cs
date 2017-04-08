using Entities.Domain;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class GenreController : DefaultController<Genre, IGenreRepository>
    {
        public GenreController(IUnitOfWork unitOfWork, IGenreRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}