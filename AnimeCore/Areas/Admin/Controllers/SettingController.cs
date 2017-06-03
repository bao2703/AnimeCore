using System;
using AnimeCore.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;

namespace AnimeCore.Areas.Admin.Controllers
{
    public class SettingController : AdminController
    {
        private readonly AppSettings _appSettings;
        private readonly Authentication _authentication;

        public SettingController(IOptionsSnapshot<AppSettings> appSettings,
            IOptionsSnapshot<Authentication> authentication)
        {
            _authentication = authentication.Value;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            var model = new SettingViewModel
            {
                PageSize = _appSettings.PageSize,
                FacebookAppId = _authentication.Facebook.AppId,
                FacebookAppSecret = _authentication.Facebook.AppSecret
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SettingViewModel model)
        {
            _appSettings.PageSize = model.PageSize;
            _authentication.Facebook.AppId = model.FacebookAppId;
            _authentication.Facebook.AppSecret = model.FacebookAppSecret;
            return View(model);
        }

        public IActionResult Slide()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSlide(int movieId)
        {
            if (!_appSettings.Slide.Contains($"{movieId},"))
            {
                _appSettings.Slide = _appSettings.Slide + $"{movieId},";
            }
            return RedirectToAction("Slide");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSlide(int movieId)
        {
            _appSettings.Slide = _appSettings.Slide.Replace($"{movieId},", string.Empty);
            return RedirectToAction("Slide");
        }
    }
}