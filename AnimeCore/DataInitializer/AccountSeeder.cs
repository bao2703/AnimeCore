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
                },
                {
                    User, new Role
                    {
                        Name = User,
                        Description = "User"
                    }
                }
            };

            foreach (var role in roles.Values)
            {
                await roleService.CreateAsync(role);
            }

            await roleService.AddClaimAsync(roles[Manager], new Claim(ClaimTypes.Role, Administrator));

            //var permissionRepository = app.ApplicationServices.GetService<IPermissionRepository>();

            //var controllers = Helper.GetControllers(typeof(AdminController).Namespace).ToList();
            //foreach (var controller in controllers)
            //{
            //    foreach (var action in Helper.GetActions(controller))
            //    {
            //        permissionRepository.Add(new Permission
            //        {
            //            Role = roles[Administrator],
            //            Action = action,
            //            Controller = controller.Name
            //        });
            //    }
            //}
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