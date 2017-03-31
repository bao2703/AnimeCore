using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models.RoleViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var model = _roleService.ToList().Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                NumberOfUsers = x.Users.Count
            });
            return View(model);
        }

        public IActionResult AddEdit()
        {
            var model = new RoleViewModel();
            return PartialView(model);
        }
    }
}