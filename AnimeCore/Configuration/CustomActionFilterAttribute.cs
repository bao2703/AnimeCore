using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;

namespace AnimeCore.Configuration
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public CustomAuthorizeAttribute(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
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
                return;
            }

            context.Result = new ChallengeResult();
        }
    }
}