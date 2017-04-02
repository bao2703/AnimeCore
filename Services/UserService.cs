﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User user, string password, string role);
        Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo userLoginInfo);
        List<User> ToList();
        Task<User> FindByIdAsync(string id);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> UpdateAsync(User user, string role);
        Task<IdentityResult> DeleteAsync(User user);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        Task<IdentityResult> RemoveFromRoleAsync(User user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> role);
        Task<IList<string>> GetRolesAsync(User user);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(User user)
        {
            return await _userManager.CreateAsync(user);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password, string role)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }

        public async Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo userLoginInfo)
        {
            return await _userManager.AddLoginAsync(user, userLoginInfo);
        }

        public List<User> ToList()
        {
            return _userManager.Users.Include(x => x.Roles).ToList();
        }

        public Task<User> FindByIdAsync(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public Task<IdentityResult> UpdateAsync(User user)
        {
            return _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> UpdateAsync(User user, string role)
        {
            var roles = await GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (result.Succeeded)
                result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }

        public Task<IdentityResult> DeleteAsync(User user)
        {
            return _userManager.DeleteAsync(user);
        }

        public Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }

        public Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
        {
            return _userManager.RemoveFromRoleAsync(user, role);
        }

        public Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> role)
        {
            return _userManager.RemoveFromRolesAsync(user, role);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return _userManager.GetRolesAsync(user);
        }
    }
}