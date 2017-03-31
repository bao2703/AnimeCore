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
                    Email = model.UserName
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

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        #endregion
    }
}