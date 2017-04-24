using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnimeCore.Configuration
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
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

            if (user.HasClaim(controller, action))
            {
                return;
            }

            context.Result = new ChallengeResult();
        }
    }
}