using System;
using Entities;
using Entities.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeCore.Configuration
{
    public static class IdentityConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<NeptuneContext>()
                .AddDefaultTokenProviders();

            var userOptions = new UserOptions {RequireUniqueEmail = true};

            var passwordOptions = new PasswordOptions
            {
                RequireDigit = false,
                RequiredLength = 1,
                RequireNonAlphanumeric = false,
                RequireUppercase = false,
                RequireLowercase = false
            };

            var lockoutOptions = new LockoutOptions
            {
                DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1),
                MaxFailedAccessAttempts = 10
            };

            var cookieOptions = new IdentityCookieOptions
            {
                ApplicationCookie = new CookieAuthenticationOptions
                {
                    LoginPath = "/Account/Login",
                    LogoutPath = "/Account/Logout",
                    AccessDeniedPath = "/Error/403",
                    ExpireTimeSpan = TimeSpan.FromMinutes(30),
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true
                }
            };

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = passwordOptions;
                options.Lockout = lockoutOptions;
                options.User = userOptions;
                options.Cookies = cookieOptions;
            });
        }
    }
}