using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeCore.Common;
using Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.UserViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class UserController : AdminIdentityController
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new List<UserListViewModel>();
            foreach (var item in _userService.ToList())
            {
                model.Add(new UserListViewModel
                {
                    Id = item.Id,
                    Email = item.Email,
                    UserName = item.UserName,
                    EmailConfirmed = item.EmailConfirmed,
                    RoleName = (await _userService.GetRolesAsync(item)).FirstOrDefault()
                });
            }
            return View(model.AsEnumerable());
        }

        public IActionResult Add()
        {
            ViewData["RoleList"] = _roleService.ToList();
            return PartialView("_AddPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await _userService.CreateAsync(user, model.Password, model.RoleName);
                if (result.Succeeded)
                {
                    return JsonStatus.Ok;
                }
                AddErrors(result);
            }
            ViewData["RoleList"] = _roleService.ToList();
            return PartialView("_AddPartial", model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                RoleName = (await _userService.GetRolesAsync(user)).FirstOrDefault()
            };
            ViewData["RoleList"] = _roleService.ToList();
            return PartialView("_EditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.Email = model.Email;
                user.UserName = model.UserName;
                var result = await _userService.UpdateAsync(user, model.RoleName);
                if (result.Succeeded)
                {
                    return JsonStatus.Ok;
                }
                AddErrors(result);
            }
            ViewData["RoleList"] = _roleService.ToList();
            return PartialView("_EditPartial", model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                RoleName = (await _userService.GetRolesAsync(user)).FirstOrDefault()
            };
            return PartialView("_DeletePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return NotFound();
                }
                var result = await _userService.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return JsonStatus.Ok;
                }
                AddErrors(result);
            }
            return PartialView("_DeletePartial", model);
        }
    }
}