using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    public interface IAccountService
    {
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure);
        Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null);
        Task RefreshSignInAsync(User user);
        Task SignOutAsync();
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        List<AuthenticationDescription> GetExternalAuthenticationSchemes();
    }

    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;

        public AccountService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public bool IsSignedIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberMe,
            bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure);
        }

        public async Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null)
        {
            await _signInManager.SignInAsync(user, isPersistent, authenticationMethod);
        }

        public async Task RefreshSignInAsync(User user)
        {
            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            return await _signInManager.GetExternalLoginInfoAsync();
        }

        public async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey,
            bool isPersistent)
        {
            return await _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
        }

        public List<AuthenticationDescription> GetExternalAuthenticationSchemes()
        {
            return _signInManager.GetExternalAuthenticationSchemes().ToList();
        }
    }
}