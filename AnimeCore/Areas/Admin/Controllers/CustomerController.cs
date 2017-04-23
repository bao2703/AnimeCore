using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class CustomerController : DefaultController<Customer, ICustomerRepository>
    {
        public CustomerController(IUnitOfWork unitOfWork, ICustomerRepository repository) : base(unitOfWork, repository)
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

        public override Task<IActionResult> Add(Customer model)
        {
            ViewData["Action"] = "Add";
            return base.Add(model);
        }

        public override IActionResult Edit(int id)
        {
            ViewData["Action"] = "Edit";
            return base.Edit(id);
        }

        public override Task<IActionResult> Edit(Customer model)
        {
            ViewData["Action"] = "Edit";
            return base.Edit(model);
        }

        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<IActionResult> Delete(Customer model)
        {
            return base.Delete(model);
        }
    }
}