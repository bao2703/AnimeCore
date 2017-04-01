using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.UserViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var model = _userService.ToList().Select(x => new UserListViewModel
            {
                Id = x.Id,
                Email = x.Email,
                UserName = x.UserName,
                EmailConfirmed = x.EmailConfirmed
            });
            return View(model);
        }

        public IActionResult Add()
        {
            return PartialView("_AddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await _accountService.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return Json(new
                    {
                        status = "Ok"
                    });
                AddErrors(result);
            }
            return PartialView("_AddPartial", model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = await _userService.FindByIdAsync(id);
                if (user != null)
                {
                    var model = new UserViewModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.UserName
                    };
                    return PartialView("_EditPartial", model);
                }
            }
            return PartialView("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;
                    var result = await _userService.UpdateAsync(user);
                    if (result.Succeeded)
                        return Json(new
                        {
                            status = "Ok"
                        });
                    AddErrors(result);
                }
            }
            return PartialView("_EditPartial", model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        #endregion
    }
}