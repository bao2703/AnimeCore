using System.Security.Claims;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.AccountViewModels;
using Services;

namespace AnimeCore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            if (_accountService.IsSignedIn(User))
                return RedirectToLocal(returnUrl);
            ViewData[Constant.ReturnUrl] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData[Constant.ReturnUrl] = returnUrl;
            if (!ModelState.IsValid) return View(model);
            var result = await _accountService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded) return RedirectToLocal(returnUrl);
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData[Constant.ReturnUrl] = returnUrl;
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData[Constant.ReturnUrl] = returnUrl;
            if (!ModelState.IsValid) return View(model);
            var user = new User {UserName = model.Email, Email = model.Email};
            var result = await _accountService.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _accountService.SignInAsync(user, false);
                return RedirectToLocal(returnUrl);
            }
            AddErrors(result);
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new {ReturnUrl = returnUrl});
            var properties = _accountService.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login");
            }
            var info = await _accountService.GetExternalLoginInfoAsync();
            if (info == null) return RedirectToAction("Login");

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _accountService.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (result.Succeeded) return RedirectToLocal(returnUrl);

            // If the user does not have an account, then ask the user to create an account.
            ViewData[Constant.ReturnUrl] = returnUrl;
            ViewData[Constant.LoginProvider] = info.LoginProvider;
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel {Email = email});
        }

        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model,
            string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _accountService.GetExternalLoginInfoAsync();
                if (info == null) return View("ExternalLoginFailure");
                var user = new User {UserName = model.Email, Email = model.Email};
                var result = await _accountService.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _accountService.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _accountService.SignInAsync(user, false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}