using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Models.ClaimViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class ClaimController : AdminController
    {
        private readonly IRoleService _roleService;

        public ClaimController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index(string roleId)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            ViewData["Role"] = role;

            var model = Constant.Claims.Select(x => new ClaimViewModel
            {
                Controller = x.Type,
                Action = x.Value
            });

            return View(model);
        }
    }
}