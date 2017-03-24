using System;
using Entities;
using Entities.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeCore.Configuration
{
    public static class IdentityConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
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

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = passwordOptions;
                options.Lockout = lockoutOptions;
                options.User = userOptions;

                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/SignIn";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/SignOut";
            });
        }
    }
}