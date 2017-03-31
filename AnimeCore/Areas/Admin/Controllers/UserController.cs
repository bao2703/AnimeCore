using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.UserViewModels;
using Services;

namespace AnimeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = _userService.ToList().Select(x => new UserViewModel()
            {
                Id = x.Id,
                Email = x.Email,
                UserName = x.UserName,
                EmailConfirmed = x.EmailConfirmed
            });
            return View(model);
        }
    }
}