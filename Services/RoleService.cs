using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IRoleService
    {
        List<Role> ToList();
        Task<Role> FindByIdAsync(string roleId);
        Task<IdentityResult> CreateAsync(Role role);
        Task<IdentityResult> UpdateAsync(Role role);
        Task<IdentityResult> DeleteAsync(Role role);
        Task<bool> RoleExistsAsync(string role);
    }

    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public List<Role> ToList()
        {
            return _roleManager.Roles.Include(x => x.Users).ToList();
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            return _roleManager.FindByIdAsync(roleId);
        }

        public Task<IdentityResult> CreateAsync(Role role)
        {
            return _roleManager.CreateAsync(role);
        }

        public Task<IdentityResult> UpdateAsync(Role role)
        {
            return _roleManager.UpdateAsync(role);
        }

        public Task<IdentityResult> DeleteAsync(Role role)
        {
            return _roleManager.DeleteAsync(role);
        }

        public Task<bool> RoleExistsAsync(string role)
        {
            return _roleManager.RoleExistsAsync(role);
        }
    }
}