using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var model = (await _roleService.GetClaimsAsync(role)).Select(x => new ClaimViewModel
            {
                Action = x.Value,
                Controller = x.Type
            });
            return View(model);
        }

        public async Task<IActionResult> Add(string roleId)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            ViewData["Role"] = role;

            var controllers = Helper.GetControllers(typeof(AdminController).Namespace).ToList();
            ViewData["ControllerList"] =
                controllers.Select(controller => controller.Name.Replace("Controller", ""))
                    .Select(controllerName => new SelectListItem
                    {
                        Value = controllerName,
                        Text = controllerName
                    }).ToList();

            return View();
        }

        public async Task<IActionResult> GetActions(string roleId, string controllerName)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return Json(new
                {
                    status = "NotFound"
                });
            }

            var actions = Helper.GetActions(controllerName, typeof(AdminController).Namespace).Distinct();

            var claims = role.Claims.Select(x => new ClaimViewModel
            {
                Action = x.ClaimValue,
                Controller = x.ClaimType
            });

            return Json(new
            {
                status = "Ok",
                claims,
                actions
            });
        }
    }
}