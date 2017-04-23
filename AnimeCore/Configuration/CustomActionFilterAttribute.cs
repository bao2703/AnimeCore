using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;

namespace AnimeCore.Configuration
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public CustomActionFilterAttribute(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionDescriptor = (ControllerActionDescriptor) context.ActionDescriptor;
            var controller = actionDescriptor.ControllerName;
            var action = actionDescriptor.ActionName;

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var user = await _userService.GetUserAsync(context.HttpContext.User);
            var roleName = await _userService.GetRolesAsync(user);
            var role = await _roleService.FindByNameAsync(roleName.First());
            var claims = await _roleService.GetClaimsAsync(role);

            if (claims.Any(x => x.Type == controller && x.Value == action))
            {
                await next();
                return;
            }

            context.Result = new ChallengeResult();
        }
    }
}