using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IRoleService : IIdentityService<Role>
    {
        Task<bool> RoleExistsAsync(string role);
        Task<IdentityResult> AddClaimAsync(Role role, Claim claim);
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

        public Task<Role> FindByNameAsync(string roleName)
        {
            return _roleManager.FindByNameAsync(roleName);
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

        public Task<IdentityResult> AddClaimAsync(Role role, Claim claim)
        {
            return _roleManager.AddClaimAsync(role, claim);
        }

        public Task<IList<Claim>> GetClaimsAsync(Role role)
        {
            return _roleManager.GetClaimsAsync(role);
        }
    }
}