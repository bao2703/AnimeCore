using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace AnimeCore.DataInitializer
{
    public class AccountSeeder
    {
        public static async Task InitializeAsync(IApplicationBuilder app)
        {
            await RoleInitializeAsync(app);
            await UserInitializeAsync(app);
        }

        private static async Task UserInitializeAsync(IApplicationBuilder app)
        {
            var userService = app.ApplicationServices.GetService<IUserService>();
            var admin = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };
            await userService.CreateAsync(admin, "admin", "Administrator");
        }

        private static async Task RoleInitializeAsync(IApplicationBuilder app)
        {
            var roleService = app.ApplicationServices.GetService<IRoleService>();

            if (!await roleService.RoleExistsAsync("Administrator"))
            {
                var role = new Role
                {
                    Name = "Administrator",
                    Description = "Administrator"
                };
                await roleService.CreateAsync(role);
            }
            if (!await roleService.RoleExistsAsync("Super User"))
            {
                var role = new Role
                {
                    Name = "Super User",
                    Description = "Super User"
                };
                await roleService.CreateAsync(role);
            }
            if (!await roleService.RoleExistsAsync("Manager"))
            {
                var role = new Role
                {
                    Name = "Manager",
                    Description = "Manager"
                };
                await roleService.CreateAsync(role);
            }
        }
    }
}