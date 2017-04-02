using System.Collections.Generic;
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

        public static async Task InitializeAsync(IApplicationBuilder app)
        {
            await InitializeRoleAsync(app);
            await InitializeUserAsync(app);
        }

        private static async Task InitializeUserAsync(IApplicationBuilder app)
        {
            var userService = app.ApplicationServices.GetService<IUserService>();
            var users = new List<User>
            {
                new User
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                },
                new User
                {
                    UserName = "superuser@gmail.com",
                    Email = "superuser@gmail.com"
                }
            };
            foreach (var user in users)
                await userService.CreateAsync(user, "Bao@2703", Administrator);
        }

        private static async Task InitializeRoleAsync(IApplicationBuilder app)
        {
            var roleService = app.ApplicationServices.GetService<IRoleService>();
            var roles = new List<Role>
            {
                new Role
                {
                    Name = Administrator,
                    Description = "Administrator"
                },
                new Role
                {
                    Name = SuperUser,
                    Description = "Super User"
                },
                new Role
                {
                    Name = Manager,
                    Description = "Manager"
                }
            };
            foreach (var role in roles)
                await roleService.CreateAsync(role);
        }
    }
}