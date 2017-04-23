using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
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

        public override IActionResult Index()
        {
            return base.Index();
        }

        public override IActionResult Add()
        {
            ViewData["Action"] = "Add";
            return base.Add();
        }

        public override Task<IActionResult> Add(Genre model)
        {
            ViewData["Action"] = "Add";
            return base.Add(model);
        }

        public override IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            return base.Edit(id);
        }

        public override Task<IActionResult> Edit(Genre model)
        {
            ViewData["Action"] = "Edit";
            return base.Edit(model);
        }

        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<IActionResult> Delete(Genre model)
        {
            return base.Delete(model);
        }
    }
}