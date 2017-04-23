using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
        private const string User = "User";

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
                        Name = Administrator,
                        Description = "Administrator"
                    }
                },
                {
                    Manager, new Role
                    {
                        Name = Administrator,
                        Description = "Administrator"
                    }
                },
                {
                    User, new Role
                    {
                        Name = Administrator,
                        Description = "Administrator"
                    }
                }
            };

            foreach (var role in roles)
            {
                await roleService.CreateAsync(role.Value);
            }

            var claim = new Claim("Role", "Index");
            await roleService.AddClaimAsync(roles[Administrator], claim);
        }

        private static async Task InitializeUserAsync(IApplicationBuilder app)
        {
            var userService = app.ApplicationServices.GetService<IUserService>();
            var users = new List<User>
            {
                new User
                {
                    UserName = "bao2703@gmail.com",
                    Email = "bao2703@gmail.com"
                },
                new User
                {
                    UserName = "bao2703@gmail.com2",
                    Email = "bao2703@gmail.com2"
                }
            };

            await userService.CreateAsync(users[0], "1", Administrator);
            await userService.CreateAsync(users[1], "1", Manager);
        }
    }
}