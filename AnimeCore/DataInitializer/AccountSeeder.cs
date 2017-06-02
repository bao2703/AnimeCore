using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace AnimeCore.DataInitializer
{
    public class AccountSeeder
    {
        private const string Administrator = "Administrator";
        private const string SuperUser = "Super User";
        private const string Manager = "Manager";

        public static async Task InitializeAsync(IApplicationBuilder app)
        {
            await InitializeRoleAsync(app);
            await InitializeUserAsync(app);
        }

        private static async Task InitializeRoleAsync(IApplicationBuilder app)
        {
            var roleService = app.ApplicationServices.GetService<IRoleService>();
            var roles = new Dictionary<string, Role>
            {
                {
                    Administrator, new Role
                    {
                        Name = Administrator,
                        Description = "Administrator"
                    }
                },
                {
                    SuperUser, new Role
                    {
                        Name = SuperUser,
                        Description = "SuperUser"
                    }
                },
                {
                    Manager, new Role
                    {
                        Name = Manager,
                        Description = "Manager"
                    }
                }
            };

            foreach (var role in roles.Values)
            {
                await roleService.CreateAsync(role);
            }

            foreach (var claim in Constant.Claims)
            {
                await roleService.AddClaimAsync(roles[Administrator], new Claim(claim.Type, claim.Value));
                if (claim.Type == "User" || claim.Type == "Role" || claim.Type == "Claim")
                {
                    await roleService.AddClaimAsync(roles[SuperUser], new Claim(claim.Type, claim.Value));
                }
                if (claim.Type == "Movie" || claim.Type == "Episode")
                {
                    await roleService.AddClaimAsync(roles[Manager], new Claim(claim.Type, claim.Value));
                }
            }
        }

        private static async Task InitializeUserAsync(IApplicationBuilder app)
        {
            var userService = app.ApplicationServices.GetService<IUserService>();
            var users = new List<User>
            {
                new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com"
                },
                new User
                {
                    UserName = "manager",
                    Email = "manager@gmail.com"
                }
            };

            await userService.CreateAsync(users[0], "1", Administrator);
            await userService.CreateAsync(users[1], "1", Manager);
        }
    }
}