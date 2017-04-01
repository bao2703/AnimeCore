using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimeCore.Common
{
    public abstract class IdentityController : Controller
    {
        #region Helpers

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        #endregion
    }
}