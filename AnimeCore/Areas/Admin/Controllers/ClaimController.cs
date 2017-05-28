using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Models.ClaimViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class ClaimController : AdminIdentityController
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
                Action = x.Value,
                IsEnabled = false
            }).ToList();

            var claims = await _roleService.GetClaimsAsync(role);

            foreach (var item in model)
            {
                if (claims.Any(roleClaim =>
                    roleClaim.Type == item.Controller && roleClaim.Value == item.Action))
                {
                    item.IsEnabled = true;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string controllerName, string actionName, string roleId,
            string operation)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return JsonStatus.Error;
            }
            dynamic result;
            switch (operation)
            {
                case "Enable":
                    result = await _roleService.AddClaimAsync(role, new Claim(controllerName, actionName));
                    break;
                case "Disable":
                    result = await _roleService.RemoveClaimAsync(role, new Claim(controllerName, actionName));
                    break;
                default:
                    return JsonStatus.Error;
            }
            if (result.Succeeded)
            {
                return JsonStatus.Ok;
            }
            AddErrors(result);
            return JsonStatus.Error;
        }
    }
}