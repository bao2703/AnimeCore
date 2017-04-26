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
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public CustomAuthorizeAttribute(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var actionDescriptor = (ControllerActionDescriptor) context.ActionDescriptor;
            var controller = actionDescriptor.ControllerName;
            var action = actionDescriptor.ActionName;

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await _accountService.RefreshSignInAsync(await _userService.GetUserAsync(user));

            if (user.HasClaim(controller, action))
            {
                return;
            }

            context.Result = new ChallengeResult();
        }
    }
}