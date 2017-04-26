﻿using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Models.ClaimViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class ClaimController : AdminIdentityController
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public ClaimController(IRoleService roleService, IAccountService accountService, IUserService userService)
        {
            _roleService = roleService;
            _accountService = accountService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string roleId)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }
            ViewData["Role"] = role;

            var model = Constant.Claims.Select(x => new ClaimViewModel
            {
                Controller = x.Type,
                Action = x.Value,
                IsLocked = false
            }).ToList();

            var claims = await _roleService.GetClaimsAsync(role);

            foreach (var item in model)
            {
                if (claims.Any(roleClaim =>
                    roleClaim.Type == item.Controller && roleClaim.Value == item.Action))
                {
                    item.IsLocked = true;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string controllerName, string actionName, string roleId, string operation)
        {
            var role = await _roleService.FindByIdAsync(roleId);
            if (role == null)
            {
                return JsonStatus.Error;
            }
            dynamic result;
            if (operation == "Add")
            {
                result = await _roleService.AddClaimAsync(role, new Claim(controllerName, actionName));
            }
            else
            {
                result = await _roleService.RemoveClaimAsync(role, new Claim(controllerName, actionName));
            }
            if (result.Succeeded)
            {
                var users = _userService.GetUsersInRole(role.Id).ToList();
                foreach (var user in users)
                {
                    result = await _userService.UpdateSecurityStampAsync(user);
                    if (!result.Succeeded)
                    {
                        return JsonStatus.Error;
                    }
                }
                return JsonStatus.Ok;
            }
            AddErrors(result);
            return JsonStatus.Error;
        }
    }
}