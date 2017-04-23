using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var a = User.Claims.ToList();
            var model = await _roleService.GetClaimsAsync(role);
            return View(model);
        }

        public async Task<IActionResult> Add(string roleId)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            var model = await _roleService.GetClaimsAsync(role);
            return View(model);
        }
    }
}