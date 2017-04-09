using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
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

        public override IActionResult Add()
        {
            ViewData["Action"] = "Add";
            return base.Add();
        }

        public override Task<IActionResult> Add(Movie model)
        {
            ViewData["Action"] = "Add";
            return base.Add(model);
        }

        public override IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            return base.Edit(id);
        }

        public override Task<IActionResult> Edit(Movie model)
        {
            ViewData["Action"] = "Edit";
            return base.Edit(model);
        }
    }
}