using Entities.Domain;
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
    }
}